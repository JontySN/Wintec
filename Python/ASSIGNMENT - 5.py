"""
Author: Jonty Southcombe-Nguyen 14407227
Pledge of honour: I pledge by honour that this program is soley my own work
Description: determine grocery discount eligibility
"""

while True: #opening up a while true loop
    prod_price = float(input("Enter product price (<0): ")) #setting up a variable from user input
    if prod_price >0: #if the greater than 0
     break #breaks loop
    else: #if the price is not greater than 0 the command is executed below    
     print('Invalid input, please re-enter')

while True:
    prod_quan = int(input("Enter quantity (>0): "))
    if prod_quan >0:
     break
    else:     
     print('Invalid input, please re-enter')

while True:
    prod_discount = input("Have you claimed the discount before (Y/N): ")
    if prod_discount ==  "Y" or prod_discount ==  "N" or prod_discount ==  'y' or prod_discount ==  'n': #ASSIGNING A VARIABLE TO THE INPUT
     break
    else:     
     print('Invalid input')

total_shopping_amount = prod_price * prod_quan#calculating the total shopping amount
print('Total shopping amount: $', total_shopping_amount) #printing message with assigned variable
print('Eligible for discount? ', prod_discount)

if total_shopping_amount <= 500 and (prod_discount == "n" or prod_discount == "N"):
   print("You are eligable")
else:
   print("Sorry, you are not eligible")






