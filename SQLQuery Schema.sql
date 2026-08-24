/* =====================================================================
   Schema.sql — ONE unified database for the merged CompanyApp
   Server: (localdb)\MSSQLLocalDB
   ===================================================================== */

/* ---------- 1. Create the single database ---------- */
IF DB_ID('dbCompanyApp') IS NULL
    CREATE DATABASE dbCompanyApp;
GO

USE dbCompanyApp;
GO

/* ---------- 2. Users table ---------- */
IF OBJECT_ID('dbo.Emp_details', 'U') IS NOT NULL DROP TABLE dbo.Emp_details;
IF OBJECT_ID('dbo.Users', 'U')       IS NOT NULL DROP TABLE dbo.Users;
GO

CREATE TABLE dbo.Users
(
    UserID    INT           IDENTITY(1,1) NOT NULL,
    Username  NVARCHAR(50)  NOT NULL,
    Password  NVARCHAR(200) NOT NULL,          -- SHA-256 hex hash
    CreatedAt DATETIME      NOT NULL CONSTRAINT DF_Users_Created DEFAULT (GETDATE()),

    CONSTRAINT PK_Users       PRIMARY KEY (UserID),
    CONSTRAINT UQ_Users_Uname UNIQUE (Username)
);
GO

/* ---------- 3. Emp_details table ---------- */
CREATE TABLE dbo.Emp_details
(
    EmpId      NVARCHAR(50)  NOT NULL,
    EmpName    NVARCHAR(100) NOT NULL,
    EmpAge     INT           NOT NULL,
    EmpContact NVARCHAR(20)  NULL,
    EmpGender  NVARCHAR(10)  NULL,
    CreatedBy  INT           NULL,             -- links to the user who created it

    CONSTRAINT PK_Emp_details   PRIMARY KEY (EmpId),
    CONSTRAINT FK_Emp_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES dbo.Users(UserID)
);
GO

/* ---------- 4. Migrated Access accounts ----------
   Login credentials to test with (plain text -> stored hash):
     admin / admin123
     sayan / pass123
*/
INSERT INTO dbo.Users (Username, [Password]) VALUES
    ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9'),
    ('sayan', '9b8769a4a742959a2d0298c36fb70623f2dfacda8436237df08d8dfd5b37374c');
GO

/* ---------- 5. Sample employee rows ---------- */
INSERT INTO dbo.Emp_details (EmpId, EmpName, EmpAge, EmpContact, EmpGender, CreatedBy) VALUES
    ('E001', 'Farook', 25, '01711065621', 'Female', NULL),
    ('E002', 'salman',  30, '01912535302', 'Male',   NULL);
GO

/* ---------- 6. Verify ---------- */
SELECT * FROM dbo.Users;
SELECT e.EmpId, e.EmpName, e.EmpAge, e.EmpContact, e.EmpGender, u.Username AS CreatedBy
FROM   dbo.Emp_details e
LEFT JOIN dbo.Users u ON e.CreatedBy = u.UserID;
GO