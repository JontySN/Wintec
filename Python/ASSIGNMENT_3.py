"""
Author: Jonty Southcombe-Nguyen 14407227
Pledge of honour: I pledge by honour that this program is soley my own work
Description: this program determines how many hours a user has worked and their total pay
"""


#heres where you put your name, pay rate, and also you hours youve completed
input("Name: ")
pay = float(input("Please enter in your hourly rate: $"))
#print("Please enter you previous weeks hours: ")

#this is to display days and allocate hours
wksum = float(input("Please enter you previous weeks hours: : "))
wksum = (wksum) * pay #this simplyfies the maths by creating variables

wkndsum = float(input("Please enter your weekend hours if needed below: "))
wkndsum = (wkndsum * 2 * pay) #this also creates simplified variables so the math isnt messy below 

#here are the total hours and pay from the weekends all added together
print("Your total weekday pay is: ${:.2f}".format(wksum))
#weekend pay is * by 2 because its double pay on weekends
print("Your total weekend pay is: ${:.2f}".format(wkndsum))
print("Your total pay amount is:  ${:.2f}".format( wksum + wkndsum))
#print("area of the circle: {:.6f}".format(area))




