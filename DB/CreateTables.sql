-- Create table: Users
CREATE TABLE public.Users
(
    CustomerId SERIAL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Surname VARCHAR(50) NOT NULL
);

-- Create table: Accounts
CREATE TABLE public.Accounts
(
    AccountId SERIAL PRIMARY KEY,
    CustomerId INT NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES public.Users(CustomerId)
);

-- Create table: AccountTransactions
CREATE TABLE public.AccountTransactions
(
    TransactionId SERIAL PRIMARY KEY,
    AccountId INT NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    TransactionDate DATE NOT NULL,
    FOREIGN KEY (AccountId) REFERENCES public.Accounts(AccountId)
);

-- Insert dummy data into Users table
INSERT INTO public.Users (Name, Surname)
VALUES
    ('John', 'Doe'),
    ('Jane', 'Smith'),
    ('Michael', 'Johnson');

-- Insert dummy data into Accounts table
INSERT INTO public.Accounts (CustomerId, Balance)
VALUES
    (1, 1000.00),
    (2, 500.00),
    (3, 1500.00);

-- Insert dummy data into AccountTransactions table
INSERT INTO public.AccountTransactions (AccountId, Amount, TransactionDate)
VALUES
    (1, -100.00, '2023-05-01'),
    (1, -50.00, '2023-05-05'),
    (2, -200.00, '2023-05-02'),
    (3, 100.00, '2023-05-03');
