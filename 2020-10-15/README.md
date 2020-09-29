# 2020-10-15
Code example from http://hicks2evan.github.io/2020/10/15/trivial-analytics/
Includes link to Jupyter notebook project, and some details for configuring the jeopardy_db to run local.

## Jupyter notebook
The notebook with the code found in this project can be accessed here https://github.com/hicks2evan/trivial_analytics/blob/master/trivial_analyics.ipynb

Pull that repo to run it yourself.

## What is, 'database'?
1. Set up MySQL on your local https://dev.mysql.com/doc/mysql-getting-started/en/
2. Use favorite tool to decompress and load db from `jeopardy_db.sql.zip` in this directory
3. Make sure to create a user and give them permissions to the added database, my Jupyter notebook uses a user with these credentials: service/jeopardy! and allows local connections only