"""
Author: Jonty Southcombe-Nguyen 14407227
Pledge of honour: I pledge by honour that this program is soley my own work
Description: to record the box office pay and names of movie
"""
film_list = [] #opens list
film_list.append(['FM01', 'Stealth', 135, 80])
film_list.append(['FM02', 'Supernova', 90, 15])
film_list.append(['FM03', 'Robin Hood', 100, 85])
film_list.append(['FM04', 'Rollerball', 70, 26])
film_list.append(['FM05', 'Rust', 85, 20])

print(f'{"title":<20}{"Box-office"}') #prints header

print("-" * 30) #to dispplay the breaker

for rec in film_list: #prints rec 1 (name) and 3 (boxoffice) with an even 20 spacing
    print(f"{rec[1]:<20}{rec[3]}")

print() # creates gap

print("Film count: ", (len(film_list))) #prints total movies


print(film_list)#prints the film_list for loop command