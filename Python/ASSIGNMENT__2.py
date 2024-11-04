"""
Author: Jonty Southcombe-Nguyen 14407227
Pledge of honour: I pledge by honour that this program is soley my own work
Description: this program determines the radius and surface area of a cirlce
"""

import math #imports the math extension

#asks the user to enter the radius of the circle
radius = float(input("enter the radius of the cirle: "))

#calculates the area and the perimeter of pi
perimeter = radius * 2 * math.pi
area = radius ** 2 * math.pi

#shows the results with 6 decimal points
print("perimeter of the circle: {:.6f}".format(perimeter))
print("area of the circle: {:.6f}".format(area))
