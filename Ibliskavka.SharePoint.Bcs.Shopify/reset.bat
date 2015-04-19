REM Simple batch file to reset IIS and warm up Central Admin and my demo site. Remove or replace with your URLs.
iisreset
start "C:\Program Files\Internet Explorer\iexplore.exe" http://crm2013/bcsdemo/_layouts/15/viewlsts.aspx
start "C:\Program Files\Internet Explorer\iexplore.exe" http://crm2013:5000/applications.aspx