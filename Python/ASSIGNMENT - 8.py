"""
Author: Jonty Southcombe-Nguyen 14407227
Pledge of honour: I pledge by honour that this program is soley my own work
Description: to record the box office pay and names of movie
"""


def get_records():#calling function name
    film_list = []#opens list
    rec = ['FM01', 'Stealth', 135, 80]#assigns a variable to the records
    film_list.append(rec)
    rec = ['FM02', 'Supernova', 90, 15]
    film_list.append(rec)
    rec = ['FM03', 'Robin Hood', 100, 85]
    film_list.append(rec)
    rec = ['FM04', 'Rollerball', 70, 26]
    film_list.append(rec)
    rec = ['FM05', 'Rust', 85, 20]#
    film_list.append(rec)

    return film_list 

def display_list(data):#calling function for a display list
    h1, h2, h3, h4 = "ID", "Title", "Budget", "Box-office"#assigns variables to the titles/headers
    print(f'{h1:<20}{h2:<20}{h3:<20}{h4}') #prints header
    print("-" * 70) #to dispplay the breaker
    for rec in data: #prints titles with an even 20 spacing
        print(f"{rec[0]:<20}{rec[1]:<20}{rec[2]:<20}{rec[3]}") #prints recs and the :.<(number here) is the spacing

def search_by_film_id(data):#defining the search_by_film_id "variable"
    film_id = input("Enter film ID: ")#asks user to input the film id
    rec_found = None #flag variable
    for rec in data:#creates a for loop within the data
        if film_id.lower() == rec[0].lower():#if the film id is equal to the record
            rec_found = rec #update flag variable
            break
    if rec_found == None:
       print(f"No record for {film_id}")
    else:
        print(f"Film matching the given id: {rec_found[1]}")
        print(f"Budget loss for film {rec_found[1]}: {rec[2]-rec[3]}")

def main():
   rec_list = get_records()
   display_list(rec_list)
   search_by_film_id(rec_list)
#complete the call of search_by_film_id function here
#Hint: the function is no-return function
main()

