import java.util.Scanner;

public class App {
    public static void main(String[] args) {
        SumOddNumbers();
    }

    public static void SumOddNumbers() {
        var sc = new Scanner(System.in);

        var n = Integer.parseInt(sc.nextLine());

        var sum = 0;
        var counter = 1;
        for (int i = 0; i < n; i++) {
            System.out.println(counter);
            sum += counter;
            counter += 2;
        }
        System.out.printf("Sum: %d", sum);
    }

    public static void DivisableByThree() {
        for (int i = 3; i < 100; i += 3) {
            System.out.println(i);
        }
    }

    public static void TheatrePromotions() {
        var sc = new Scanner(System.in);

        String typeOfDay = sc.nextLine().toLowerCase();
        int age = Integer.parseInt(sc.nextLine());

        String message = "";

        if (0 <= age && age <= 18) {
            switch (typeOfDay) {
            case "weekday":
                message = "12$";
                break;
            case "weekend":
                message = "15$";
                break;
            case "holiday":
                message = "5$";
                break;
            }
        } else if (18 < age && age <= 64) {
            switch (typeOfDay) {
            case "weekday":
                message = "18$";
                break;
            case "weekend":
                message = "20$";
                break;
            case "holiday":
                message = "12$";
                break;
            }
        } else if (64 < age && age <= 122) {
            switch (typeOfDay) {
            case "weekday":
                message = "12$";
                break;
            case "weekend":
                message = "15$";
                break;
            case "holiday":
                message = "10$";
                break;
            }
        } else {
            message = "Error!";
        }

        System.out.println(message);
    }

    public static void ForeignLanguages() {
        Scanner sc = new Scanner(System.in);

        String country = sc.nextLine();

        switch (country) {
        case "England":
        case "USA":
            System.out.println("English");
            break;
        case "Spain":
        case "Argentina":
        case "Mexico":
            System.out.println("Spanish");
        default:
            System.out.println("unknown");
            break;
        }
    }

    public static void BackInThirtyMinutes() {
        Scanner sc = new Scanner(System.in);

        int hours = Integer.parseInt(sc.nextLine());
        int minutes = Integer.parseInt(sc.nextLine());

        int totalMinutesAfter30 = hours * 60 + minutes + 30;
        int totalMinutesToHours = totalMinutesAfter30 / 60;
        int totalMinutesRemainder = totalMinutesAfter30 % 60;

        if (totalMinutesToHours > 23) {
            totalMinutesToHours -= 24;

        }
        System.out.printf("%d:%02d", totalMinutesToHours, totalMinutesRemainder);
    }

}