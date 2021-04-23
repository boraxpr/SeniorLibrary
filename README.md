# SeniorLibrary
Required .NET Core, MySQL Community(Preferred)
Create a root user password=6501. 

# Get started
1. cd to directory
2. command > code -r
3. dotnet tool install --global dotnet-ef
4. dotnet ef database update (populate tables)
5. run app !

## Admin identity
Username : ictadmin
Password : 123Pa$$word.

## Users identity
SeniorLibrary\users.json

# Group 21
*    Naipawat Poolsawat
*    Nohrarit Saengsukhiran
*    Katesudarad Saikate
## Senior Project Library Website for Senior Project Digital Library System
#### /Identity/Account/Login
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/Log%20in.png)

#### Authenticated
#### Home As admin
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/logged%20as%20admin.png)
#### Home As student
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/logged%20as%20student.png)
#### Home As lecturer
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/logged%20as%20lecturer.png)
#### /Requests
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/Show%20requests.png)

#### /Requests/Create
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/Create%20requests.png)

#### /Requests/Edit?id=${EntryingID}
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/Edit.png)

#### /Requests/Details?id=${EntryingID}
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/details.png)

#### /Requests/Delete?id=${EntrytingID} (Only Authorized Admin)
![alt_text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/delete.png)

#### /Roles (Only Authorized Admin)
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/roles.png)

#### /UserRoles (Only Authorized Admin)
![alt text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/userroles.png)

#### /Upload (Only Authorized Admin, Staff, Lecturer)
![alt_text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/upload.png)

#### /Download (Only Authorized Admin, Staff, Lecturer)
![alt_text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/download.png)

### /Download/Download?id=${BookID} (Only Authorized Admin, Staff, Lecturer)
![alt_text](https://raw.githubusercontent.com/boraxpr/SeniorLibrary/main/download_confirm.png)




