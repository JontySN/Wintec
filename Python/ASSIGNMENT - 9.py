"""
Author: Jonty Southcombe-Nguyen 14407227
Pledge of honour: I pledge by honour that this program is soley my own work
Description: to record the box office pay and names of movie
"""


def get_records():
    film_list = []#opens up the records list
    rec = ['FM01', 'Stealth', 135, 80]
    film_list.append(rec)
    rec = ['FM02', 'Supernova', 90, 15]
    film_list.append(rec)
    rec = ['FM03', 'Robin Hood', 100, 85]
    film_list.append(rec)
    rec = ['FM04', 'Rollerball', 70, 26]
    film_list.append(rec)
    rec = ['FM05', 'Rust', 85, 20]
    film_list.append(rec)

    return film_list

def display_list(data):
    h1, h2, h3, h4 = "ID", "Title", "Budget", "Box-office"#assigning the titles to variables
    print(f'{h1:<20}{h2:<20}{h3:<20}{h4}') #prints header
    print("-" * 70) #to dispplay the breaker
    for rec in data: #prints titles with an even 20 spacing
        print(f"{rec[0]:<20}{rec[1]:<20}{rec[2]:<20}{rec[3]}")#prints the records

def search_by_film_id(data):
    film_id = input("Enter film ID: ")#asks user to input a film id and assigns it to a variable
    rec_found = None #flag variable
    for rec in data:
        if film_id.lower() == rec[0].lower():
            rec_found = rec #update flag variable
            break
    if rec_found == None:#if the code cant find the record
       print(f"No record for {film_id}")
    else:
        print(f"Film matching the given id: {rec_found[1]}")
        print(f"Budget loss for film {rec_found[1]}: {rec[2]-rec[3]}")
        
def get_total_budget_loss(data):
    total = 0 #setting the total to 0
    for rec in data:
        total += rec[2] - rec[3] #calculating the total loss
    return total

def main():
   rec_list = get_records()
   display_list(rec_list)
   search_by_film_id(rec_list)
   loss = get_total_budget_loss(rec_list)
   print(f"Total budget loss of all films: {loss}") #prints total loss of all films under the variable "loss"

main()