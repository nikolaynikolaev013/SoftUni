import java.util.Scanner;

public class App {
    public static void main(String[] args) throws Exception {
        Scanner sc = new Scanner(System.in);
    }

    public static void Login(Scanner sc) {
        // You will be given a string representing a username. The password will be that
        // username reversed. Until you receive the correct password print on the
        // console "Incorrect password. Try again.". When you receive the correct
        // password print "User {username} logged in." However on the fourth try if the
        // password is still not correct print "User {username} blocked!" and end the
        // program.

        String username = sc.nextLine();
        String pass = "";

        byte[] usernameAsBytes = username.getBytes();
        byte[] temp = new byte[username.length()];

        boolean isSuccessful = false;

        for (int i = 0; i < username.length(); i++) {
            temp[i] = usernameAsBytes[username.length() - i - 1];
        }
        pass = new String(temp);

        for (int i = 0; i < 4; i++) {
            String tryPass = sc.nextLine();

            if (pass.equals(tryPass)) {
                isSuccessful = true;
                break;
            } else if (i < 3) {
                System.out.println("Incorrect password. Try again.");
            }
        }

        if (isSuccessful) {
            System.out.println(String.format("User %s logged in.", username));
        } else {
            System.out.println(String.format("User sunny blocked!", username));
        }
    }

    public static String PrintAndSum(Scanner sc) {
        // Write a program to display numbers from given start to given end and their
        // sum. All the numbers will be integers. On the first line you will receive the
        // start number, on the second the end number.

        int start = Integer.parseInt(sc.nextLine());
        int end = Integer.parseInt(sc.nextLine());

        StringBuilder sb = new StringBuilder();

        int sum = 0;

        for (int i = start; i <= end; i++) {
            sb.append(i + " ");
            sum += i;
        }

        sb.append(String.format("\nSum: %d", sum));
        return sb.toString().trim();
    }

    public static String Vacation(Scanner sc) {
        // You are given a group of people, type of the group, on which day of the week
        // they are going to stay. Based on that information calculate how much they
        // have to pay and print that price on the console. Use the table below. In each
        // cell is the price for a single person. The output should look like that:
        // "Total price: {price}". The price should be formatted to the second decimal
        // point.

        // There are also discounts based on some conditions:
        // • Students – if the group is bigger than or equal to 30 people you should
        // reduce the total price by 15%
        // • Business – if the group is bigger than or equal to 100 people 10 of them
        // can stay for free.
        // • Regular – if the group is bigger than or equal 10 and less than or equal to
        // 20 reduce the total price by 5%
        // You should reduce the prices in that EXACT order

        int numOfPeople = Integer.parseInt(sc.nextLine());
        String typeOfGroup = sc.nextLine().toLowerCase();
        String weekDay = sc.nextLine().toLowerCase();

        double totalCost = 1;

        double pricePerPerson = 0.0;

        switch (weekDay) {
        case "friday":
            if (typeOfGroup.equals("students")) {
                pricePerPerson = 8.45;
            } else if (typeOfGroup.equals("business")) {
                pricePerPerson = 10.90;
            } else if (typeOfGroup.equals("regular")) {
                pricePerPerson = 15;
            }
            break;
        case "saturday":
            if (typeOfGroup.equals("students")) {
                pricePerPerson = 9.80;
            } else if (typeOfGroup.equals("business")) {
                pricePerPerson = 15.60;
            } else if (typeOfGroup.equals("regular")) {
                pricePerPerson = 20;
            }
            break;
        case "sunday":
            if (typeOfGroup.equals("students")) {
                pricePerPerson = 10.46;
            } else if (typeOfGroup.equals("business")) {
                pricePerPerson = 16;
            } else if (typeOfGroup.equals("regular")) {
                pricePerPerson = 22.50;
            }
            break;
        }

        totalCost = pricePerPerson * numOfPeople;

        switch (typeOfGroup.toLowerCase()) {
        case "students":
            if (numOfPeople >= 30) {
                totalCost *= 0.85;
            }
            break;
        case "business":
            if (numOfPeople >= 100) {
                totalCost = pricePerPerson * (numOfPeople - 10);
            }
            break;
        case "regular":
            if (numOfPeople >= 10 && numOfPeople <= 20) {
                totalCost *= 0.95;
            }
            break;
        }

        return String.format("Total price: %.2f", totalCost);
    }

    public static String Division(Scanner sc) {
        // You will be given an integer and you have to print on the console whether
        // that number is divisible by the following numbers: 2, 3, 6, 7, 10. You should
        // always take the bigger division. If the number is divisible by both 2 and 3
        // it is also divisible by 6 and you should print only the division by 6. If a
        // number is divisible by 2 it is sometimes also divisible by 10 and you should
        // print the division by 10. If the number is not divisible by any of the given
        // numbers print “Not divisible”. Otherwise print "The number is divisible by
        // {number}".

        int number = Integer.parseInt(sc.nextLine());
        var divisableBy = -1;

        if (number % 10 == 0) {
            divisableBy = 10;
        } else if (number % 7 == 0) {
            divisableBy = 7;
        } else if (number % 6 == 0) {
            divisableBy = 6;
        } else if (number % 3 == 0) {
            divisableBy = 3;
        } else if (number % 2 == 0) {
            divisableBy = 2;
        }

        if (divisableBy != -1) {
            return "The number is divisible by " + divisableBy;
        } else {
            return "Not divisible";
        }
    }

    public static String Ages(Scanner sc) {
        // Write a program that determines whether based on the given age a person is:
        // baby, child, teenager, adult, elder. The bounders are:
        // • 0-2 – baby;
        // • 3-13 – child;
        // • 14-19 – teenager;
        // • 20-65 – adult;
        // • >=66 – elder;
        // • All the values are inclusive.
        var age = Integer.parseInt(sc.nextLine());
        var message = "";

        if (age >= 0 && age <= 2) {
            message = "baby";
        } else if (age >= 3 && age <= 13) {
            message = "child";
        } else if (age >= 14 && age <= 19) {
            message = "teenager";
        } else if (age >= 20 && age <= 65) {
            message = "adult";
        } else if (age >= 66) {
            message = "elder";
        }

        return message;
    }
}
