CREATE TABLE IF NOT EXISTS public."User" (
    "CustomerId" character varying(255) NOT NULL,
    "Name" character varying(255) NOT NULL,
    "LastName" character varying(255) NOT NULL,
    "Address" character varying(255) NOT NULL,
    "PhoneNumber" character varying(255) NOT NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("CustomerId")
);
CREATE TABLE IF NOT EXISTS public."Account" (
    "AccountId" character varying(255) NOT NULL,
    "CustomerId" character varying(255) NOT NULL,
    "Balance" numeric(18, 2) NOT NULL,
    CONSTRAINT "PK_Account" PRIMARY KEY ("AccountId"),
    CONSTRAINT "FK_Account_User_CustomerId" FOREIGN KEY ("CustomerId")
        REFERENCES public."User" ("CustomerId") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS public."AccountTransaction" (
    "TransactionId" character varying(255) NOT NULL,
    "AccountId" character varying(255) NOT NULL,
    "Amount" numeric(18, 2) NOT NULL,
    "TransactionDate" timestamp without time zone NOT NULL,
    "TransactionType" integer NOT NULL,
    CONSTRAINT "PK_AccountTransaction" PRIMARY KEY ("TransactionId"),
    CONSTRAINT "FK_AccountTransaction_Account_AccountId" FOREIGN KEY ("AccountId")
        REFERENCES public."Account" ("AccountId") ON DELETE CASCADE
);
