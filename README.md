# CompanyApp

This is my submission for the "merge two applications" lab. I had two working apps from earlier labs — a Login/Register app that used an Access database (OleDb) and an Employee CRUD app that used SQL Server (SqlClient) — and the task was to combine them into a single WinForms solution with one database and one login-gated CRUD flow.

Everything runs in one project now: `CompanyApp`, namespace `EmployeeDetails` (I kept the original namespace name so I didn't have to touch every file — more on that below).

## What the app does

1. `frmLogin` — log in with a username/password.
2. `frmRegister` — create a new account if you don't have one.
3. `frmDashboard` — after login, shows a searchable grid of all employees, plus who added each one.
4. `frmEmployee` — the actual CRUD screen (add/edit/delete employees), opened from the dashboard.

Test login: `admin / admin123` or `sayan / pass123` (these get inserted by Schema.sql — see below).

## Database

One database, `dbCompanyApp`, on `(localdb)\MSSQLLocalDB`. Run `SQLQuery Schema.sql` first before opening the project — it creates the DB, both tables, and drops in a couple of sample rows.

```
dbo.Users          UserID (PK), Username, Password, CreatedAt
dbo.Emp_details    EmpId (PK), EmpName, EmpAge, EmpContact, EmpGender, CreatedBy (FK -> Users.UserID)
```

`CreatedBy` is the link between the two old apps — it's how the dashboard grid can show which logged-in user added each employee.

## The six things I had to actually decide on

**1. Two data providers, one provider.** The login app was OleDb + Access (`.mdb`), the CRUD app was SqlClient + SQL Server. Access doesn't scale and honestly it's a pain to distribute, so everything moved to SqlClient. All the old OleDb code in the login/register forms got rewritten to use `SqlConnection`/`SqlCommand` against the same connection string the CRUD app already had in `App.config`.

**2. Two databases, one database.** Instead of two separate DBs I put `Users` and `Emp_details` in the same `dbCompanyApp` database so they could actually reference each other with a foreign key. The old Access user rows got re-inserted as SQL rows (with their passwords re-hashed, see #4).

**3. Two `Main()` entry points, one.** Both original apps had their own `Program.cs` that opened a different form first. Only one `Main()` can exist in a single exe, so I kept `frmLogin` as the start form and deleted the other entry point. Also had to make sure closing the login form on the X button actually calls `Application.Exit()` — otherwise the process can hang around invisibly if a form was only `Hide()`-den earlier instead of closed.

**4. Passwords weren't hashed.** The original login app stored plain-text passwords, which I wasn't comfortable just carrying over. Added a `Security.cs` with a small SHA-256 helper, used it in both register and login, and re-hashed the two sample accounts in the schema script to match. This wasn't strictly required but it felt wrong to skip it.

**5. No relationship between users and employees.** The two apps had nothing to say about who created what. Added `Emp_details.CreatedBy` as a nullable FK to `Users.UserID`, stamp it from `Session.UserID` whenever an employee is added, and changed the employee SELECT to a `LEFT JOIN` (not an inner join — an inner join would've hidden the old rows that have `CreatedBy = NULL`).

**6. Inconsistent naming and file structure.** The CRUD app's main form was still called `Form1`, and the two projects used different conventions for class names, query strings, etc. Renamed `Form1` to `frmEmployee`, matched it to the `frm` prefix the login forms already used, and rewrote the new `User.cs` data-access class to follow the same "one class, SQL as constants, connection string pulled once from config" pattern that `Employee.cs` already used, instead of inventing a second pattern.

While I was in the registration form I also noticed the empty-field check used `&&` instead of `||`, so it only complained when *every* box was empty at once. Fixed that too since it's directly in the code I was already merging.

## What's not in the repo

`bin/`, `obj/`, `.vs/`, and anything Access-related (`.mdb`/`.ldb`/`.accdb`) are gitignored — this app doesn't touch Access at all anymore, so there's no reason for those files to exist here.
