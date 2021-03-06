/*SET SCHEMA APP;


DROP TABLE USERS;
DROP TABLE USERACCOUNTROLES;
DROP TABLE ROLE;
DROP TABLE PERMISSIONS;
DROP TABLE CONTRACTOR;
DROP TABLE REPORT;
*/

/* USER TABLE
userID
PasswordHash
firstName
creationDate
expiryDate
*/

CREATE TABLE USERS
(
	userID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	userName VARCHAR(40) NOT NULL,
	passwordHash VARCHAR(250) NOT NULL,
	fullName VARCHAR(40) NOT NULL,
	creationDate DATE NOT NULL
)


/*Contractor TABLE

contractorID
companyID
hstNumber
LegalName
*/

CREATE TABLE CONTRACTOR
(
	contractorID INT NOT NULL PRIMARY KEY,
	companyID INT NOT NULL,
	hstNumber INT NOT NULL,
	legalName VARCHAR(50) NOT NULL
);

/*Permissions TABLE
PermissionID
companyID
*/

CREATE TABLE PERMISSION
(
	permissionsID INT NOT NULL PRIMARY KEY,
	contractorID INT NOT NULL,
	CONSTRAINT companyFK
		FOREIGN KEY (contractorID)
		REFERENCES CONTRACTOR(contractorID)
);

/*Role Permissions TABLE
ROleID
permissionsID
*/
CREATE TABLE ROLEPERMISSIONS
(
	roleID INT NOT NULL PRIMARY KEY,
	roleName VARCHAR(50) NOT NULL,
	permissionsID INT NOT NULL
	CONSTRAINT permissionsFK
		FOREIGN KEY (permissionsID)
		REFERENCES PERMISSION(permissionsID)
	
);

/*userAccountRoles TABLE
UserID
RoleID
*/

CREATE TABLE USERACCOUNTROLES
(
	userID INT NOT NULL,
	roleID INT NOT NULL,
	CONSTRAINT userFK
		FOREIGN KEY (userID)
		REFERENCES USERS(userID),
	CONSTRAINT roleFK
		FOREIGN KEY (roleID)
		REFERENCES ROLEPERMISSIONS(roleID)
);



/*Report TABLE
reportID
contractorID
date
isCertified
ceritifactionPDF
*/

CREATE TABLE REPORT
(
	reportID INT NOT NULL PRIMARY KEY,
	contractorID INT NOT NULL,
	date DATE,
	isCertified BIT
	
	CONSTRAINT contractorFK
		FOREIGN KEY (contractorID)
		REFERENCES CONTRACTOR(contractorID)
);