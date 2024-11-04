"""
Author: Jonty Southcombe-Nguyen 14407227
Pledge of honour: I pledge by honour that this program is soley my own work
Description: to demo the elif function
"""

day= input("Enter a number (1-7): ")#asks user to enter a number
if day == "1":#for example if day equals 1...
    message = "Monday sucks"#display message "Monday sucks"
elif day == "2":#elif means "else if" witch kinda mean "if its not that its this"
    message = "its Tuesday"
elif day == "3":
    message = "hump day Wednesday"
elif day == "4":
    message = "regular Thursday"
elif day == "5":
    message = "its Friday!"
elif day == "6":
    message = "Party hard Saturday"
elif day == "7":
    message = "chill Sunday"
else:
    message = "Mysterious day"
print(message)#prints the message