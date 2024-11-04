def read_data(filename):
    records = []
    with open(filename) as fr:
        lines = fr.readlines()
        for line in lines:
            line = line.strip()
            if len(line) == 0:
                continue
            str_rec = line.split(",")
            store_ID = str_rec[0].strip()
            employees = int(str_rec[1].strip())
            suburb_name = str_rec[2].strip()
            sale_volume = float(str_rec[3].strip())
            rec = [store_ID, employees, suburb_name, sale_volume]
            records.append(rec)
    return records

def print_all_records(records):
    pass

def write_data(filename, records):
    with open(filename, "w") as fw:
        for rec in records:
            fw.write(f"{rec[0]:>10}{rec[1]:>10}{rec[2]:>10}{rec[3]:>10}")

def get_min_sale_record(records):
    min_rec = records[2] #Use second rec as candidate
    for rec in records:
        if rec[3] < min_rec[3]:
            min_rec = rec #Update candidate
    return min_rec
    
def query_suburb_stats(records):
    suburb = input("Enter suburb name: ")
    total_quantity, rec_count = 0, 0
    for rec in records:
        if suburb.lower() == rec[2].lower():
            total_quantity += rec[3]
            rec_count += 1
            avg_sale = rec[3]/2
    if rec_count == 0:
        print(f"No record was found for suburb {suburb}")
    else:
        print(f"Total sales by {suburb}: {rec[3]}")
        print(f"Average sale by {suburb}: {avg_sale}")
           

def count_employees(records):
    pass


def main():
    data = read_data('data1.txt')
    min_sale_rec = get_min_sale_record(data)
    print_all_records(data)
    query_suburb_stats(data)
    write_data('data1.txt', data)
    print(f"The minimum sale volume is: ${min_sale_rec[3]}")
    print(f"The suburb with the minimum sale is: {min_sale_rec[2]}")
    

main()