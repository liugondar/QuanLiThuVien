for %%G in (*.sql) do sqlcmd /S servername /d databaseName -E -i"%%G"
pause