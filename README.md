# Countify

A financial dashboard used to manage fees inside an organisation 


Currently the API is composed of two controllers:
    
    - The accounts controller, which is responsible for managing users accounts
    - The tax controller, which is responsible for managing financial operations

Endpoints available in the system are as follows:

    - Accounts:
        1. register
        2. login
        3. Edit
        4. get
        5. get penalties
        6. get all (Debug only)

    - Tax:
        1. update balance
        2. add penalty
        3. add fees

The API is using authentication and authorization based on JWT, and defines the following roles inside the system:

 1. SubMember
 2. Member
 3. HouseKeeper
 4. MoneyKeeper
 5. VicePresident
 6. President
 7. Administrator 