# Steps to run the migration of database

1. Open Package Manager Console
2. Set Project to where DBContext File is there
3. Below comment below line of code 

File : CatalogServiceDbContext, 
Line: Comment below line

optionsBuilder.UseSqlServer(_config[GlobalConstants.CONNECTIONSTRING]);

4. Run add-migration <filename> on Package Manager Console
-- Replace <filename>  with proper file name to generate migration script

5. Run update-database -verbose to update database


