export interface Transaction {
    amount: number;
    transactionDate: string;
    transactionType: number;
  }
  
  export interface Account {
    balance: number;
    transactions: Transaction[];
  }
  
  export interface User {
    name: string;
    lastName: string;
    address: string;
    phoneNumber: string;
    accounts: Account[];
  }
  export interface UserCreationDto {
    Name: string;
    LastName: string;
    Address: string;
    PhoneNumber: string;
    CustomerId: string;
    InitialCredit: number;
  }
  