﻿using UnityEngine;

namespace Assets.Utils
{
    public static class AmericanNameGenerator
    {
        public enum Gender
        {
            Men,
            Woman,
            Neutral
        }

        public static string GenerateName(Gender gender)
        {
            if (gender == Gender.Woman) {
                if (Random.value < 0.5) {
                    var rnd = (int)Mathf.Floor(Random.value * nm2.Length);
                    var rnd2 = (int)Mathf.Floor(Random.value * nm3.Length);
                    return nm2[rnd] + " " + nm3[rnd2];
                }
                else {
                    var rnd = (int)Mathf.Floor(Random.value * nm5.Length);
                    var rnd2 = (int)Mathf.Floor(Random.value * nm6.Length);
                    return nm5[rnd] + " " + nm6[rnd2];
                }
            } else if (gender == Gender.Neutral) {
                if (Random.value < 0.5) {
                    var rnd = (int)Mathf.Floor(Random.value * nm7.Length);
                    var rnd2 = (int)Mathf.Floor(Random.value * nm3.Length);
                    return nm7[rnd] + " " + nm3[rnd2];
                } else {
                    var rnd = (int)Mathf.Floor(Random.value * nm7.Length);
                    var rnd2 = (int)Mathf.Floor(Random.value * nm6.Length);
                    return nm7[rnd] + " " + nm6[rnd2];
                }
            }
            else {
                if (Random.value < 0.5) {
                    var rnd = (int)Mathf.Floor(Random.value * nm1.Length);
                    var rnd2 = (int)Mathf.Floor(Random.value * nm3.Length);
                    return nm1[rnd] + " " + nm3[rnd2];
                } else {
                    var rnd = (int)Mathf.Floor(Random.value * nm4.Length);
                    var rnd2 = (int)Mathf.Floor(Random.value * nm6.Length);
                    return nm4[rnd] + " " + nm6[rnd2];
                }
            }
        }


        //=== Lookup Tables ===
        //--- ripped from https://www.fantasynamegenerators.com/english-names.php ---

        private static string[] nm1 = {
            "Aaron", "Adam", "Aidan", "Aiden", "Alex", "Alexander", "Alfie", "Andrew", "Anthony", "Archie",
            "Arthur", "Ashton", "Bailey", "Ben", "Benjamin", "Billy", "Blake", "Bobby", "Bradley", "Brandon", "Caleb",
            "Callum", "Cameron", "Charles", "Charlie", "Christopher", "Cody", "Connor", "Corey", "Daniel", "David", "Declan"
                , "Dexter", "Dominic", "Dylan", "Edward", "Elliot", "Ellis", "Ethan", "Evan", "Ewan", "Finlay", "Finley",
            "Frankie", "Freddie", "Frederick", "Gabriel", "George", "Harley", "Harrison", "Harry", "Harvey", "Hayden",
            "Henry", "Isaac", "Jack", "Jackson", "Jacob", "Jake", "James", "Jamie", "Jay", "Jayden", "Jenson", "Joe", "Joel"
                , "John", "Jonathan", "Jordan", "Joseph", "Josh", "Joshua", "Jude", "Kai", "Kayden", "Kian", "Kieran", "Kyle",
            "Leo", "Leon", "Lewis", "Liam", "Logan", "Louie", "Louis", "Luca", "Lucas", "Luke", "Mason", "Matthew", "Max",
            "Michael", "Morgan", "Nathan", "Nicholas", "Noah", "Oliver", "Ollie", "Oscar", "Owen", "Patrick", "Peter",
            "Reece", "Reuben", "Rhys", "Riley", "Robert", "Rory", "Ryan", "Sam", "Samuel", "Scott", "Sean", "Sebastian",
            "Spencer", "Stanley", "Taylor", "Theo", "Thomas", "Toby", "Tom", "Tommy", "Tyler", "William", "Zac", "Zachary",
            "Zak"
        };

        private static string[] nm2 =  {"Abbie", "Abby", "Abigail", "Aimee", "Alex", "Alexandra", "Alice", "Alicia", "Alisha", "Amber",
        "Amelia", "Amelie", "Amy", "Anna", "Ava", "Bella", "Bethany", "Brooke", "Caitlin", "Cerys", "Charlie",
        "Charlotte", "Chelsea", "Chloe", "Courtney", "Daisy", "Danielle", "Demi", "Eleanor", "Eliza", "Elizabeth",
        "Ella", "Ellie", "Eloise", "Elsie", "Emilia", "Emily", "Emma", "Erin", "Esme", "Eva", "Eve", "Evelyn", "Evie",
        "Faith", "Freya", "Georgia", "Georgina", "Grace", "Gracie", "Hannah", "Harriet", "Heidi", "Hollie", "Holly",
        "Imogen", "Isabel", "Isabella", "Isabelle", "Isla", "Isobel", "Jade", "Jasmine", "Jennifer", "Jessica", "Jodie",
        "Julia", "Kate", "Katherine", "Katie", "Kayla", "Kayleigh", "Keira", "Lacey", "Lara", "Laura", "Lauren", "Layla"
        , "Leah", "Lexi", "Lexie", "Libby", "Lilly", "Lily", "Lola", "Louise", "Lucy", "Lydia", "Maddison", "Madeleine",
        "Madison", "Maisie", "Maisy", "Maria", "Martha", "Matilda", "Maya", "Megan", "Melissa", "Mia", "Millie",
        "Mollie", "Molly", "Morgan", "Mya", "Naomi", "Natasha", "Niamh", "Nicole", "Olivia", "Paige", "Phoebe", "Poppy",
        "Rachel", "Rebecca", "Rose", "Rosie", "Ruby", "Samantha", "Sara", "Sarah", "Scarlett", "Shannon", "Sienna",
        "Skye", "Sofia", "Sophia", "Sophie", "Summer", "Tegan", "Tia", "Tilly", "Victoria", "Willow", "Yasmin", "Zara",
        "Zoe"};

        private static string[] nm3 =  {"Adams", "Allen", "Anderson", "Andrews", "Armstrong", "Atkinson", "Austin", "Bailey", "Baker",
        "Ball", "Barker", "Barnes", "Barrett", "Bates", "Baxter", "Bell", "Bennett", "Berry", "Black", "Booth",
        "Bradley", "Brooks", "Brown", "Burke", "Burns", "Burton", "Butler", "Byrne", "Campbell", "Carr", "Carter",
        "Chambers", "Chapman", "Clark", "Clarke", "Cole", "Collins", "Cook", "Cooke", "Cooper", "Cox", "Cunningham",
        "Davidson", "Davies", "Davis", "Dawson", "Day", "Dean", "Dixon", "Doyle", "Duncan", "Edwards", "Elliott",
        "Ellis", "Evans", "Fisher", "Fletcher", "Foster", "Fox", "Francis", "Fraser", "Gallagher", "Gardner", "George",
        "Gibson", "Gill", "Gordon", "Graham", "Grant", "Gray", "Green", "Griffiths", "Hall", "Hamilton", "Harper",
        "Harris", "Harrison", "Hart", "Harvey", "Hawkins", "Hayes", "Henderson", "Hill", "Holland", "Holmes", "Hopkins",
        "Houghton", "Howard", "Hudson", "Hughes", "Hunt", "Hunter", "Hussain", "Jackson", "James", "Jenkins", "John",
        "Johnson", "Johnston", "Jones", "Jordan", "Kaur", "Kelly", "Kennedy", "Khan", "King", "Knight", "Lane",
        "Lawrence", "Lawson", "Lee", "Lewis", "Lloyd", "Lowe", "Macdonald", "Marsh", "Marshall", "Martin", "Mason",
        "Matthews", "May", "Mccarthy", "Mcdonald", "Miller", "Mills", "Mitchell", "Moore", "Morgan", "Morris", "Moss",
        "Murphy", "Murray", "Newman", "Nicholson", "Owen", "Palmer", "Parker", "Parry", "Patel", "Pearce", "Pearson",
        "Perry", "Phillips", "Poole", "Porter", "Powell", "Price", "Read", "Rees", "Reid", "Reynolds", "Richards",
        "Richardson", "Riley", "Roberts", "Robertson", "Robinson", "Rogers", "Rose", "Ross", "Russell", "Ryan",
        "Saunders", "Scott", "Sharp", "Shaw", "Simpson", "Smith", "Spencer", "Stevens", "Stewart", "Stone", "Sutton",
        "Taylor", "Thomas", "Thompson", "Thomson", "Turner", "Walker", "Wallace", "Walsh", "Ward", "Watson", "Watts",
        "Webb", "Wells", "West", "White", "Wilkinson", "Williams", "Williamson", "Willis", "Wilson", "Wood", "Woods",
        "Wright", "Young"};

        private static string[] nm4 =  {"Aaden", "Aarav", "Aaron", "Abdiel", "Abdullah", "Abel", "Abraham", "Abram", "Ace", "Adam", "Adan",
        "Aden", "Aditya", "Adonis", "Adrian", "Adriel", "Adrien", "Agustin", "Ahmad", "Ahmed", "Aidan", "Aiden", "Aidyn"
        , "Alan", "Albert", "Alberto", "Alden", "Aldo", "Alec", "Alejandro", "Alessandro", "Alex", "Alexander", "Alexis"
        , "Alexzander", "Alfonso", "Alfred", "Alfredo", "Alijah", "Allan", "Allen", "Alonso", "Alonzo", "Alvaro",
        "Alvin", "Amari", "Ameer", "Amir", "Amos", "Anders", "Anderson", "Andre", "Andres", "Andrew", "Andy", "Angel",
        "Angelo", "Anthony", "Antoine", "Anton", "Antonio", "Apollo", "Archer", "Ari", "Arian", "Ariel", "Arjun", "Arlo"
        , "Armando", "Armani", "Arnav", "Aron", "Arthur", "Arturo", "Aryan", "Asa", "Asher", "Ashton", "Atticus",
        "August", "Augustine", "Augustus", "Austin", "Austyn", "Avery", "Axel", "Axton", "Ayaan", "Aydan", "Ayden",
        "Aydin", "Barrett", "Beau", "Beckett", "Beckham", "Ben", "Benjamin", "Bennett", "Benson", "Bentlee", "Bentley",
        "Bently", "Benton", "Billy", "Blaine", "Blaise", "Blake", "Blaze", "Bo", "Bobby", "Bodhi", "Boston", "Bowen",
        "Braden", "Bradley", "Brady", "Bradyn", "Braeden", "Braiden", "Branden", "Brandon", "Branson", "Brantley",
        "Braxton", "Brayan", "Brayden", "Braydon", "Braylen", "Braylon", "Brecken", "Brendan", "Brenden", "Brendon",
        "Brennan", "Brennen", "Brent", "Brentley", "Brenton", "Brett", "Brian", "Brice", "Bridger", "Briggs", "Brock",
        "Broderick", "Brodie", "Brody", "Brogan", "Bronson", "Brooks", "Bruce", "Bruno", "Bryan", "Bryant", "Bryce",
        "Brycen", "Bryson", "Byron", "Cade", "Caden", "Cael", "Caiden", "Cain", "Cale", "Caleb", "Callan", "Callen",
        "Callum", "Calvin", "Camden", "Camdyn", "Cameron", "Camilo", "Camren", "Camron", "Camryn", "Cannon", "Carl",
        "Carlos", "Carmelo", "Carson", "Carter", "Case", "Casen", "Casey", "Cash", "Cason", "Cassius", "Cayden",
        "Cayson", "Cedric", "Cesar", "Chace", "Chad", "Chaim", "Chance", "Chandler", "Channing", "Charles", "Charlie",
        "Chase", "Chris", "Christian", "Christopher", "Clark", "Clay", "Clayton", "Clinton", "Cody", "Cohen", "Colby",
        "Cole", "Coleman", "Colin", "Collin", "Colt", "Colten", "Colton", "Conner", "Connor", "Conor", "Conrad",
        "Cooper", "Corbin", "Corey", "Cory", "Craig", "Crew", "Cristian", "Cristopher", "Crosby", "Cruz", "Cullen",
        "Curtis", "Cyrus", "Dakota", "Dallas", "Dalton", "Damarion", "Damian", "Damien", "Damion", "Damon", "Dane",
        "Dangelo", "Daniel", "Danny", "Dante", "Darian", "Dariel", "Darien", "Dario", "Darius", "Darnell", "Darrell",
        "Darren", "Darryl", "Darwin", "Davian", "David", "Davin", "Davion", "Davis", "Davon", "Dawson", "Dax", "Daxton",
        "Dayton", "Deacon", "Dean", "Deandre", "Deangelo", "Declan", "Deegan", "Demarcus", "Demetrius", "Dennis",
        "Denzel", "Deon", "Derek", "Derick", "Derrick", "Deshawn", "Desmond", "Devan", "Devin", "Devon", "Dexter",
        "Diego", "Dillon", "Dominic", "Dominick", "Dominik", "Dominique", "Donald", "Donovan", "Donte", "Dorian",
        "Douglas", "Drake", "Draven", "Drew", "Duncan", "Dustin", "Dwayne", "Dylan", "Ean", "Easton", "Eddie", "Eden",
        "Edgar", "Edison", "Eduardo", "Edward", "Edwin", "Efrain", "Eli", "Elian", "Elias", "Elijah", "Eliot", "Eliseo",
        "Elisha", "Elliot", "Elliott", "Ellis", "Emanuel", "Emerson", "Emery", "Emiliano", "Emilio", "Emmanuel",
        "Emmett", "Emmitt", "Emory", "Enrique", "Enzo", "Eric", "Erick", "Erik", "Ernest", "Ernesto", "Esteban", "Ethan"
        , "Eugene", "Evan", "Everett", "Ezekiel", "Ezequiel", "Ezra", "Fabian", "Felipe", "Felix", "Fernando", "Finley",
        "Finn", "Finnegan", "Fisher", "Fletcher", "Flynn", "Foster", "Francis", "Francisco", "Franco", "Frank",
        "Frankie", "Franklin", "Freddy", "Frederick", "Gabriel", "Gael", "Gage", "Gaige", "Garrett", "Gary", "Gauge",
        "Gavin", "Gavyn", "George", "Gerald", "Gerardo", "Giancarlo", "Gianni", "Gibson", "Gideon", "Gilbert",
        "Gilberto", "Giovani", "Giovanni", "Giovanny", "Grady", "Graeme", "Graham", "Grant", "Graysen", "Grayson",
        "Gregory", "Greyson", "Griffin", "Guillermo", "Gunnar", "Gunner", "Gustavo", "Hamza", "Hank", "Harley", "Harold"
        , "Harper", "Harrison", "Harry", "Harvey", "Hassan", "Hayden", "Hayes", "Heath", "Hector", "Hendrix", "Henry",
        "Hezekiah", "Holden", "Houston", "Howard", "Hudson", "Hugh", "Hugo", "Hunter", "Ian", "Ibrahim", "Ignacio",
        "Iker", "Immanuel", "Isaac", "Isai", "Isaiah", "Isaias", "Ishaan", "Isiah", "Ismael", "Israel", "Issac", "Ivan",
        "Izaiah", "Izayah", "Jabari", "Jace", "Jack", "Jackson", "Jacob", "Jacoby", "Jaden", "Jadiel", "Jadon", "Jaeden"
        , "Jael", "Jagger", "Jaiden", "Jaidyn", "Jaime", "Jairo", "Jake", "Jakob", "Jalen", "Jamal", "Jamar", "Jamari",
        "Jamarion", "James", "Jameson", "Jamie", "Jamir", "Jamison", "Jared", "Jarrett", "Jase", "Jasiah", "Jason",
        "Jasper", "Javier", "Javion", "Javon", "Jax", "Jaxen", "Jaxon", "Jaxson", "Jaxton", "Jay", "Jayce", "Jaycob",
        "Jayden", "Jaydon", "Jaylen", "Jaylin", "Jaylon", "Jayson", "Jedidiah", "Jefferson", "Jeffery", "Jeffrey",
        "Jensen", "Jeremiah", "Jeremy", "Jermaine", "Jerome", "Jerry", "Jesse", "Jessie", "Jett", "Jimmy", "Jionni",
        "Joaquin", "Joe", "Joel", "Joey", "Johan", "Johann", "John", "Johnathan", "Johnathon", "Johnny", "Jon", "Jonah",
        "Jonas", "Jonathan", "Jonathon", "Jordan", "Jorden", "Jordyn", "Jorge", "Jose", "Joseph", "Joshua", "Josiah",
        "Josue", "Jovani", "Jovanni", "Joziah", "Juan", "Judah", "Jude", "Juelz", "Julian", "Julien", "Julio", "Julius",
        "Junior", "Justice", "Justin", "Justus", "Kade", "Kaden", "Kaeden", "Kael", "Kai", "Kaiden", "Kale", "Kaleb",
        "Kamari", "Kamden", "Kameron", "Kamron", "Kamryn", "Kane", "Kareem", "Karsen", "Karson", "Karter", "Kase",
        "Kasen", "Kash", "Kason", "Kayden", "Kaysen", "Kayson", "Keagan", "Keaton", "Keegan", "Keenan", "Keith",
        "Kellan", "Kellen", "Kelvin", "Kendall", "Kendrick", "Kenneth", "Kenny", "Kevin", "Khalil", "Kian", "Kieran",
        "Killian", "King", "Kingsley", "Kingston", "Knox", "Kobe", "Kody", "Kohen", "Kolby", "Kole", "Kolten", "Kolton",
        "Konner", "Konnor", "Korbin", "Krish", "Kristian", "Kristopher", "Kylan", "Kyle", "Kylen", "Kyler", "Kymani",
        "Kyree", "Kyrie", "Kyson", "Lamar", "Lance", "Landen", "Landon", "Landry", "Landyn", "Lane", "Larry", "Lawrence"
        , "Lawson", "Layne", "Layton", "Leandro", "Lee", "Legend", "Leland", "Lennon", "Lennox", "Leo", "Leon",
        "Leonard", "Leonardo", "Leonel", "Leonidas", "Leroy", "Levi", "Lewis", "Liam", "Lincoln", "Lionel", "Logan",
        "London", "Lorenzo", "Louis", "Luca", "Lucas", "Lucca", "Lucian", "Luciano", "Luis", "Luka", "Lukas", "Luke",
        "Lyric", "Mack", "Madden", "Maddox", "Maison", "Major", "Makai", "Makhi", "Malachi", "Malakai", "Malaki",
        "Malcolm", "Malik", "Manuel", "Marc", "Marcel", "Marcelo", "Marco", "Marcos", "Marcus", "Mario", "Mark",
        "Markus", "Marlon", "Marquis", "Marshall", "Martin", "Marvin", "Masen", "Mason", "Mateo", "Mathew", "Mathias",
        "Matias", "Matteo", "Matthew", "Matthias", "Maurice", "Mauricio", "Maverick", "Max", "Maxim", "Maximilian",
        "Maximiliano", "Maximo", "Maximus", "Maxton", "Maxwell", "Mayson", "Mekhi", "Melvin", "Memphis", "Messiah",
        "Micah", "Michael", "Micheal", "Miguel", "Mike", "Miles", "Milo", "Misael", "Mitchell", "Mohamed", "Mohammad",
        "Mohammed", "Moises", "Morgan", "Myles", "Nash", "Nasir", "Nathan", "Nathanael", "Nathaniel", "Nehemiah", "Neil"
        , "Nelson", "Neymar", "Nicholas", "Nickolas", "Nico", "Nicolas", "Niko", "Nikolai", "Nikolas", "Nixon", "Noah",
        "Noe", "Noel", "Nolan", "Oakley", "Odin", "Oliver", "Omar", "Omari", "Orion", "Orlando", "Oscar", "Osvaldo",
        "Otto", "Owen", "Pablo", "Parker", "Patrick", "Paul", "Paxton", "Payton", "Pedro", "Peter", "Peyton", "Philip",
        "Phillip", "Phoenix", "Pierce", "Porter", "Preston", "Prince", "Princeton", "Quentin", "Quincy", "Quinn",
        "Quintin", "Quinton", "Rafael", "Raiden", "Ramiro", "Ramon", "Randall", "Randy", "Raphael", "Rashad", "Raul",
        "Ray", "Rayan", "Rayden", "Raylan", "Raymond", "Reagan", "Reece", "Reed", "Reese", "Reginald", "Reid",
        "Remington", "Remy", "Rene", "Reuben", "Rex", "Rey", "Rhett", "Rhys", "Ricardo", "Richard", "Ricky", "Riley",
        "River", "Robert", "Roberto", "Rocco", "Roderick", "Rodney", "Rodolfo", "Rodrigo", "Rogelio", "Roger", "Rohan",
        "Roland", "Rolando", "Roman", "Romeo", "Ronald", "Ronan", "Ronin", "Ronnie", "Rory", "Ross", "Rowan", "Rowen",
        "Roy", "Royce", "Ruben", "Rudy", "Russell", "Ryan", "Ryder", "Ryker", "Rylan", "Ryland", "Rylee", "Rylen",
        "Sage", "Sam", "Samson", "Samuel", "Saul", "Sawyer", "Scott", "Seamus", "Sean", "Sebastian", "Semaj", "Sergio",
        "Seth", "Shane", "Shaun", "Shawn", "Sheldon", "Sidney", "Silas", "Simeon", "Simon", "Sincere", "Skylar",
        "Skyler", "Solomon", "Sonny", "Soren", "Spencer", "Stanley", "Stefan", "Stephen", "Sterling", "Steve", "Steven",
        "Sullivan", "Sylas", "Talon", "Tanner", "Tate", "Tatum", "Taylor", "Teagan", "Terrance", "Terrell", "Terrence",
        "Terry", "Thaddeus", "Theo", "Theodore", "Thiago", "Thomas", "Timothy", "Titan", "Titus", "Tobias", "Toby",
        "Todd", "Tomas", "Tommy", "Tony", "Trace", "Travis", "Trent", "Trenton", "Trevon", "Trevor", "Trey", "Tripp",
        "Tristan", "Tristen", "Tristian", "Tristin", "Triston", "Troy", "Truman", "Trystan", "Tucker", "Turner", "Ty",
        "Tyler", "Tyree", "Tyrell", "Tyrone", "Tyson", "Ulises", "Uriah", "Uriel", "Urijah", "Valentin", "Valentino",
        "Van", "Vance", "Vaughn", "Vicente", "Victor", "Vihaan", "Vincent", "Vincenzo", "Wade", "Walker", "Walter",
        "Warren", "Waylon", "Wayne", "Wesley", "Westin", "Weston", "Will", "William", "Willie", "Wilson", "Winston",
        "Wyatt", "Xander", "Xavi", "Xavier", "Xzavier", "Yael", "Yahir", "Yandel", "Yehuda", "Yosef", "Yousef", "Yusuf",
        "Zachariah", "Zachary", "Zackary", "Zaid", "Zaiden", "Zain", "Zaire", "Zander", "Zane", "Zavier", "Zayden",
        "Zayne", "Zechariah", "Zeke", "Zion"};

        private static string[] nm5 =  {"Sophia", "Emma", "Isabella", "Olivia", "Ava", "Emily", "Abigail", "Mia", "Madison", "Elizabeth",
        "Chloe", "Ella", "Avery", "Addison", "Aubrey", "Lily", "Natalie", "Sofia", "Charlotte", "Zoey", "Grace",
        "Hannah", "Amelia", "Harper", "Lillian", "Samantha", "Evelyn", "Victoria", "Brooklyn", "Zoe", "Layla", "Hailey",
        "Leah", "Kaylee", "Anna", "Aaliyah", "Gabriella", "Allison", "Nevaeh", "Alexis", "Audrey", "Savannah", "Sarah",
        "Alyssa", "Claire", "Taylor", "Riley", "Camila", "Arianna", "Ashley", "Brianna", "Sophie", "Peyton", "Bella",
        "Khloe", "Genesis", "Alexa", "Serenity", "Kylie", "Aubree", "Scarlett", "Stella", "Maya", "Katherine", "Julia",
        "Lucy", "Madelyn", "Autumn", "Makayla", "Kayla", "Mackenzie", "Lauren", "Gianna", "Ariana", "Faith", "Alexandra"
        , "Melanie", "Sydney", "Bailey", "Caroline", "Naomi", "Morgan", "Kennedy", "Ellie", "Jasmine", "Eva", "Skylar",
        "Kimberly", "Violet", "Molly", "Aria", "Jocelyn", "Trinity", "London", "Lydia", "Madeline", "Reagan", "Piper",
        "Andrea", "Annabelle", "Maria", "Brooke", "Payton", "Paisley", "Paige", "Ruby", "Nora", "Mariah", "Rylee",
        "Lilly", "Brielle", "Jade", "Destiny", "Nicole", "Mila", "Kendall", "Liliana", "Kaitlyn", "Natalia", "Sadie",
        "Jordyn", "Vanessa", "Mary", "Mya", "Penelope", "Isabelle", "Alice", "Reese", "Gabrielle", "Hadley", "Katelyn",
        "Angelina", "Rachel", "Isabel", "Eleanor", "Clara", "Brooklynn", "Jessica", "Elena", "Aliyah", "Vivian", "Laila"
        , "Sara", "Amy", "Eliana", "Lyla", "Juliana", "Valeria", "Adriana", "Makenzie", "Elise", "Mckenzie", "Quinn",
        "Delilah", "Cora", "Kylee", "Rebecca", "Gracie", "Izabella", "Josephine", "Alaina", "Michelle", "Jennifer",
        "Eden", "Valentina", "Aurora", "Catherine", "Stephanie", "Valerie", "Jayla", "Willow", "Daisy", "Alana",
        "Melody", "Hazel", "Summer", "Melissa", "Margaret", "Kinsley", "Kinley", "Ariel", "Lila", "Giselle", "Ryleigh",
        "Haley", "Julianna", "Ivy", "Alivia", "Brynn", "Keira", "Daniela", "Aniyah", "Angela", "Kate", "Londyn",
        "Hayden", "Harmony", "Adalyn", "Megan", "Allie", "Gabriela", "Alayna", "Presley", "Jenna", "Alexandria",
        "Ashlyn", "Adrianna", "Jada", "Fiona", "Norah", "Emery", "Maci", "Miranda", "Ximena", "Amaya", "Cecilia", "Ana",
        "Shelby", "Katie", "Hope", "Callie", "Jordan", "Luna", "Leilani", "Eliza", "Mckenna", "Angel", "Genevieve",
        "Makenna", "Isla", "Lola", "Danielle", "Chelsea", "Leila", "Tessa", "Adelyn", "Camille", "Mikayla", "Adeline",
        "Adalynn", "Sienna", "Esther", "Jacqueline", "Emerson", "Arabella", "Maggie", "Athena", "Lucia", "Lexi", "Ayla",
        "Diana", "Alexia", "Juliet", "Josie", "Allyson", "Addyson", "Delaney", "Teagan", "Marley", "Amber", "Rose",
        "Erin", "Leslie", "Kayleigh", "Amanda", "Kathryn", "Kelsey", "Emilia", "Alina", "Kenzie", "Kaydence", "Alicia",
        "Alison", "Paris", "Sabrina", "Ashlynn", "Lilliana", "Sierra", "Cassidy", "Laura", "Alondra", "Iris", "Kyla",
        "Christina", "Carly", "Jillian", "Madilyn", "Kyleigh", "Madeleine", "Cadence", "Nina", "Evangeline", "Nadia",
        "Raegan", "Lyric", "Giuliana", "Briana", "Georgia", "Yaretzi", "Elliana", "Haylee", "Fatima", "Phoebe", "Selena"
        , "Charlie", "Dakota", "Annabella", "Abby", "Daniella", "Juliette", "Lilah", "Bianca", "Mariana", "Miriam",
        "Parker", "Veronica", "Gemma", "Noelle", "Cheyenne", "Marissa", "Heaven", "Vivienne", "Brynlee", "Joanna",
        "Mallory", "Aubrie", "Journey", "Nyla", "Cali", "Tatum", "Carmen", "Gia", "Jazmine", "Heidi", "Miley", "Baylee",
        "Elaina", "Macy", "Ainsley", "Jane", "Raelynn", "Anastasia", "Adelaide", "Ruth", "Camryn", "Kiara", "Alessandra"
        , "Hanna", "Finley", "Maddison", "Lia", "Bethany", "Karen", "Kelly", "Malia", "Jazmin", "Jayda", "Esmeralda",
        "Kira", "Lena", "Kamryn", "Kamila", "Karina", "Eloise", "Kara", "Elisa", "Rylie", "Olive", "Nayeli", "Tiffany",
        "Macie", "Skyler", "Addisyn", "Angelica", "Briella", "Fernanda", "Annie", "Maliyah", "Amiyah", "Jayden",
        "Charlee", "Caitlyn", "Elle", "Crystal", "Julie", "Imani", "Kendra", "Talia", "Angelique", "Jazlyn", "Guadalupe"
        , "Alejandra", "Emely", "Lucille", "Anya", "April", "Elsie", "Madelynn", "Myla", "Julissa", "Scarlet", "Helen",
        "Breanna", "Kyra", "Madisyn", "Rosalie", "Brittany", "Brylee", "Jayleen", "Arielle", "Karla", "Kailey", "Arya",
        "Sarai", "Harley", "Miracle", "Kaelyn", "Kali", "Cynthia", "Daphne", "Aleah", "Caitlin", "Cassandra", "Holly",
        "Janelle", "Marilyn", "Katelynn", "Kaylie", "Itzel", "Carolina", "Bristol", "Haven", "Michaela", "Monica",
        "June", "Janiyah", "Camilla", "Jamie", "Rebekah", "Audrina", "Dayana", "Lana", "Serena", "Tiana", "Nylah",
        "Braelyn", "Savanna", "Skye", "Raelyn", "Madalyn", "Sasha", "Perla", "Bridget", "Aniya", "Rowan", "Logan",
        "Mckinley", "Averie", "Jaylah", "Aylin", "Joselyn", "Nia", "Hayley", "Lilian", "Adelynn", "Jaliyah", "Kassidy",
        "Kaylin", "Kadence", "Celeste", "Jaelyn", "Zariah", "Tatiana", "Jimena", "Lilyana", "Anaya", "Catalina",
        "Viviana", "Cataleya", "Sloane", "Courtney", "Johanna", "Amari", "Melany", "Anabelle", "Francesca", "Ada",
        "Alanna", "Priscilla", "Danna", "Angie", "Kailyn", "Lacey", "Sage", "Lillie", "Brinley", "Caylee", "Joy",
        "Kenley", "Vera", "Bailee", "Amira", "Aileen", "Aspen", "Emmalyn", "Erica", "Gracelyn", "Kennedi", "Skyla",
        "Annalise", "Danica", "Dylan", "Kiley", "Gwendolyn", "Jasmin", "Lauryn", "Aleena", "Justice", "Annabel",
        "Tenley", "Dahlia", "Gloria", "Lexie", "Lindsey", "Hallie", "Sylvia", "Elyse", "Annika", "Maeve", "Marlee",
        "Aryanna", "Kenya", "Lorelei", "Selah", "Kaliyah", "Adele", "Natasha", "Brenda", "Erika", "Alyson", "Braylee",
        "Emilee", "Raven", "Ariella", "Blakely", "Liana", "Jaycee", "Sawyer", "Anahi", "Jaelynn", "Elsa", "Farrah",
        "Cameron", "Evelynn", "Luciana", "Zara", "Madilynn", "Eve", "Kaia", "Helena", "Anne", "Estrella", "Leighton",
        "Nataly", "Whitney", "Lainey", "Amara", "Anabella", "Malaysia", "Samara", "Zoie", "Amani", "Phoenix", "Dulce",
        "Paola", "Marie", "Aisha", "Harlow", "Virginia", "Ember", "Regina", "Jaylee", "Anika", "Ally", "Kayden", "Alani"
        , "Miah", "Yareli", "Journee", "Kiera", "Nathalie", "Mikaela", "Jaylynn", "Litzy", "Charley", "Claudia", "Aliya"
        , "Madyson", "Cecelia", "Liberty", "Braelynn", "Evie", "Rosemary", "Myah", "Lizbeth", "Giana", "Ryan", "Teresa",
        "Ciara", "Isis", "Lea", "Shayla", "Jazlynn", "Rosa", "Gracelynn", "Desiree", "Elisabeth", "Isabela", "Arely",
        "Mariam", "Abbigail", "Emersyn", "Brenna", "Kaylynn", "Nova", "Raquel", "Dana", "Laney", "Laylah", "Siena",
        "Amelie", "Clarissa", "Lilianna", "Lylah", "Halle", "Madalynn", "Maleah", "Sherlyn", "Linda", "Shiloh", "Jessie"
        , "Kenia", "Greta", "Marina", "Melina", "Amiya", "Bria", "Natalee", "Sariah", "Mollie", "Nancy", "Christine",
        "Felicity", "Zuri", "Irene", "Simone", "Amya", "Matilda", "Colette", "Kristen", "Paityn", "Alayah", "Janiya",
        "Kallie", "Mira", "Hailee", "Kathleen", "Meredith", "Janessa", "Noemi", "Aiyana", "Aliana", "Leia", "Mariyah",
        "Tori", "Alissa", "Ivanna", "Joslyn", "Sandra", "Maryam", "Saniyah", "Kassandra", "Danika", "Denise", "Jemma",
        "River", "Charleigh", "Emelia", "Kristina", "Armani", "Beatrice", "Jaylene", "Karlee", "Blake", "Cara",
        "Addilyn", "Amina", "Ansley", "Kaitlynn", "Iliana", "Mckayla", "Adelina", "Briley", "Elaine", "Lailah",
        "Mercedes", "Chaya", "Lindsay", "Hattie", "Lisa", "Marisol", "Patricia", "Bryanna", "Taliyah", "Adrienne",
        "Emmy", "Millie", "Paislee", "Charli", "Kourtney", "Leyla", "Maia", "Willa", "Milan", "Paula", "Ayleen", "Clare"
        , "Kensley", "Reyna", "Martha", "Adley", "Elianna", "Emilie", "Karsyn", "Yasmin", "Lorelai", "Amirah", "Aryana",
        "Livia", "Alena", "Kiana", "Celia", "Kailee", "Rylan", "Ellen", "Galilea", "Kynlee", "Leanna", "Renata", "Mae",
        "Ayanna", "Chanel", "Lesly", "Cindy", "Carla", "Pearl", "Jaylin", "Kimora", "Angeline", "Carlee", "Aubri",
        "Edith", "Alia", "Frances", "Corinne", "Jocelynn", "Cherish", "Wendy", "Carolyn", "Lina", "Tabitha", "Winter",
        "Abril", "Bryn", "Jolie", "Yaritza", "Casey", "Zion", "Lillianna", "Jordynn", "Zariyah", "Audriana", "Jayde",
        "Jaida", "Salma", "Diamond", "Malaya", "Kimber", "Ryann", "Abbie", "Paloma", "Destinee", "Kaleigh", "Asia",
        "Demi", "Yamileth", "Deborah", "Elin", "Kaiya", "Mara", "Averi", "Nola", "Tara", "Taryn", "Emmalee", "Aubrianna"
        , "Janae", "Kyndall", "Jewel", "Zaniyah", "Kaya", "Sonia", "Alaya", "Heather", "Nathaly", "Shannon", "Ariah",
        "Avah", "Giada", "Lilith", "Samiyah", "Sharon", "Coraline", "Eileen", "Julianne", "Milania", "Chana", "Regan",
        "Krystal", "Rihanna", "Sidney", "Hadassah", "Macey", "Mina", "Paulina", "Rayne", "Kaitlin", "Maritza", "Susan",
        "Raina", "Hana", "Keyla", "Temperance", "Aimee", "Alisson", "Charlize", "Kendal", "Lara", "Roselyn", "Alannah",
        "Alma", "Dixie", "Larissa", "Patience", "Taraji", "Sky", "Zaria", "Aleigha", "Alyvia", "Aviana", "Bryleigh",
        "Elliot", "Jenny", "Luz", "Ali", "Alisha", "Ayana", "Campbell", "Karis", "Lilyanna", "Azaria", "Blair", "Micah",
        "Moriah", "Myra", "Lilia", "Aliza", "Giovanna", "Karissa", "Saniya", "Emory", "Estella", "Juniper", "Kairi",
        "Kenna", "Meghan", "Abrielle", "Elissa", "Rachael", "Emmaline", "Jolene", "Joyce", "Britney", "Carlie", "Haylie"
        , "Judith", "Renee", "Saanvi", "Yesenia", "Barbara", "Dallas", "Jaqueline", "Karma", "America", "Sariyah",
        "Azalea", "Everly", "Ingrid", "Lillyana", "Emmalynn", "Marianna", "Brisa", "Kaelynn", "Leona", "Libby", "Deanna"
        , "Mattie", "Miya", "Annalee", "Nahla", "Dorothy", "Kaylyn", "Rayna", "Araceli", "Cambria", "Evalyn", "Haleigh",
        "Thalia", "Jakayla", "Maliah", "Saige", "Avianna", "Charity", "Kaylen", "Raylee", "Tamia", "Aubrielle",
        "Bayleigh", "Carley", "Kailynn", "Katrina", "Belen", "Karlie", "Natalya", "Alaysia", "Celine", "Milana",
        "Monroe", "Estelle", "Meadow", "Audrianna", "Cristina", "Harlee", "Jazzlyn", "Scarlette", "Zahra", "Akira",
        "Ann", "Collins", "Kendyl", "Anabel", "Azariah", "Carissa", "Milena", "Tia", "Alisa", "Bree", "Carleigh",
        "Cheyanne", "Sarahi", "Laurel", "Kylah", "Tinley", "Kora", "Marisa", "Esme", "Sloan", "Cailyn", "Gisselle",
        "Kasey", "Kyndal", "Marlene", "Riya", "Annabell", "Aubriana", "Izabelle", "Kirsten", "Aya", "Dalilah", "Devyn",
        "Geraldine", "Analia", "Hayleigh", "Landry", "Sofie", "Tess", "Ashtyn", "Jessa", "Katalina"};

        private static string[] nm6 =  {"Abbott", "Acevedo", "Acosta", "Adams", "Adkins", "Aguilar", "Aguirre", "Albert", "Alexander",
        "Alford", "Allen", "Allison", "Alston", "Anderson", "Andrews", "Anthony", "Armstrong", "Arnold", "Ashley",
        "Atkins", "Atkinson", "Austin", "Avery", "Avila", "Ayala", "Ayers", "Bailey", "Baird", "Baker", "Baldwin",
        "Ball", "Ballard", "Banks", "Barber", "Barker", "Barlow", "Barnes", "Barnett", "Barr", "Barrera", "Barrett",
        "Barron", "Barry", "Bartlett", "Barton", "Bass", "Bates", "Battle", "Bauer", "Baxter", "Beach", "Bean", "Beard",
        "Beasley", "Beck", "Becker", "Bell", "Bender", "Benjamin", "Bennett", "Benson", "Bentley", "Benton", "Berg",
        "Berger", "Bernard", "Berry", "Best", "Bird", "Bishop", "Black", "Blackburn", "Blackwell", "Blair", "Blake",
        "Blanchard", "Blankenship", "Blevins", "Bolton", "Bond", "Bonner", "Booker", "Boone", "Booth", "Bowen", "Bowers"
        , "Bowman", "Boyd", "Boyer", "Boyle", "Bradford", "Bradley", "Bradshaw", "Brady", "Branch", "Bray", "Brennan",
        "Brewer", "Bridges", "Briggs", "Bright", "Britt", "Brock", "Brooks", "Brown", "Browning", "Bruce", "Bryan",
        "Bryant", "Buchanan", "Buck", "Buckley", "Buckner", "Bullock", "Burch", "Burgess", "Burke", "Burks", "Burnett",
        "Burns", "Burris", "Burt", "Burton", "Bush", "Butler", "Byers", "Byrd", "Cabrera", "Cain", "Calderon",
        "Caldwell", "Calhoun", "Callahan", "Camacho", "Cameron", "Campbell", "Campos", "Cannon", "Cantrell", "Cantu",
        "Cardenas", "Carey", "Carlson", "Carney", "Carpenter", "Carr", "Carrillo", "Carroll", "Carson", "Carter",
        "Carver", "Case", "Casey", "Cash", "Castaneda", "Castillo", "Castro", "Cervantes", "Chambers", "Chan",
        "Chandler", "Chaney", "Chang", "Chapman", "Charles", "Chase", "Chavez", "Chen", "Cherry", "Christensen",
        "Christian", "Church", "Clark", "Clarke", "Clay", "Clayton", "Clements", "Clemons", "Cleveland", "Cline", "Cobb"
        , "Cochran", "Coffey", "Cohen", "Cole", "Coleman", "Collier", "Collins", "Colon", "Combs", "Compton", "Conley",
        "Conner", "Conrad", "Contreras", "Conway", "Cook", "Cooke", "Cooley", "Cooper", "Copeland", "Cortez", "Cote",
        "Cotton", "Cox", "Craft", "Craig", "Crane", "Crawford", "Crosby", "Cross", "Cruz", "Cummings", "Cunningham",
        "Curry", "Curtis", "Dale", "Dalton", "Daniel", "Daniels", "Daugherty", "Davenport", "David", "Davidson", "Davis"
        , "Dawson", "Day", "Dean", "Decker", "Dejesus", "Delacruz", "Delaney", "Deleon", "Delgado", "Dennis", "Diaz",
        "Dickerson", "Dickson", "Dillard", "Dillon", "Dixon", "Dodson", "Dominguez", "Donaldson", "Donovan", "Dorsey",
        "Dotson", "Douglas", "Downs", "Doyle", "Drake", "Dudley", "Duffy", "Duke", "Duncan", "Dunlap", "Dunn", "Duran",
        "Durham", "Dyer", "Eaton", "Edwards", "Elliott", "Ellis", "Ellison", "Emerson", "England", "English", "Erickson"
        , "Espinoza", "Estes", "Estrada", "Evans", "Everett", "Ewing", "Farley", "Farmer", "Farrell", "Faulkner",
        "Ferguson", "Fernandez", "Ferrell", "Fields", "Figueroa", "Finch", "Finley", "Fischer", "Fisher", "Fitzgerald",
        "Fitzpatrick", "Fleming", "Fletcher", "Flores", "Flowers", "Floyd", "Flynn", "Foley", "Forbes", "Ford",
        "Foreman", "Foster", "Fowler", "Fox", "Francis", "Franco", "Frank", "Franklin", "Franks", "Frazier", "Frederick"
        , "Freeman", "French", "Frost", "Fry", "Frye", "Fuentes", "Fuller", "Fulton", "Gaines", "Gallagher", "Gallegos",
        "Galloway", "Gamble", "Garcia", "Gardner", "Garner", "Garrett", "Garrison", "Garza", "Gates", "Gay", "Gentry",
        "George", "Gibbs", "Gibson", "Gilbert", "Giles", "Gill", "Gillespie", "Gilliam", "Gilmore", "Glass", "Glenn",
        "Glover", "Goff", "Golden", "Gomez", "Gonzales", "Gonzalez", "Good", "Goodman", "Goodwin", "Gordon", "Gould",
        "Graham", "Grant", "Graves", "Gray", "Green", "Greene", "Greer", "Gregory", "Griffin", "Griffith", "Grimes",
        "Gross", "Guerra", "Guerrero", "Guthrie", "Gutierrez", "Guy", "Guzman", "Hahn", "Hale", "Haley", "Hall",
        "Hamilton", "Hammond", "Hampton", "Hancock", "Haney", "Hansen", "Hanson", "Hardin", "Harding", "Hardy", "Harmon"
        , "Harper", "Harrell", "Harrington", "Harris", "Harrison", "Hart", "Hartman", "Harvey", "Hatfield", "Hawkins",
        "Hayden", "Hayes", "Haynes", "Hays", "Head", "Heath", "Hebert", "Henderson", "Hendricks", "Hendrix", "Henry",
        "Hensley", "Henson", "Herman", "Hernandez", "Herrera", "Herring", "Hess", "Hester", "Hewitt", "Hickman", "Hicks"
        , "Higgins", "Hill", "Hines", "Hinton", "Hobbs", "Hodge", "Hodges", "Hoffman", "Hogan", "Holcomb", "Holden",
        "Holder", "Holland", "Holloway", "Holman", "Holmes", "Holt", "Hood", "Hooper", "Hoover", "Hopkins", "Hopper",
        "Horn", "Horne", "Horton", "House", "Houston", "Howard", "Howe", "Howell", "Hubbard", "Huber", "Hudson", "Huff",
        "Huffman", "Hughes", "Hull", "Humphrey", "Hunt", "Hunter", "Hurley", "Hurst", "Hutchinson", "Hyde", "Ingram",
        "Irwin", "Jackson", "Jacobs", "Jacobson", "James", "Jarvis", "Jefferson", "Jenkins", "Jennings", "Jensen",
        "Jimenez", "Johns", "Johnson", "Johnston", "Jones", "Jordan", "Joseph", "Joyce", "Joyner", "Juarez", "Justice",
        "Kane", "Kaufman", "Keith", "Keller", "Kelley", "Kelly", "Kemp", "Kennedy", "Kent", "Kerr", "Key", "Kidd", "Kim"
        , "King", "Kinney", "Kirby", "Kirk", "Kirkland", "Klein", "Kline", "Knapp", "Knight", "Knowles", "Knox", "Koch",
        "Kramer", "Lamb", "Lambert", "Lancaster", "Landry", "Lane", "Lang", "Langley", "Lara", "Larsen", "Larson",
        "Lawrence", "Lawson", "Leach", "Leblanc", "Lee", "Leon", "Leonard", "Lester", "Levine", "Levy", "Lewis",
        "Lindsay", "Lindsey", "Little", "Livingston", "Lloyd", "Logan", "Long", "Lopez", "Lott", "Love", "Lowe",
        "Lowery", "Lucas", "Luna", "Lynch", "Lynn", "Lyons", "Macdonald", "Macias", "Mack", "Madden", "Maddox",
        "Maldonado", "Malone", "Mann", "Manning", "Marks", "Marquez", "Marsh", "Marshall", "Martin", "Martinez", "Mason"
        , "Massey", "Mathews", "Mathis", "Matthews", "Maxwell", "May", "Mayer", "Maynard", "Mayo", "Mays", "Mcbride",
        "Mccall", "Mccarthy", "Mccarty", "Mcclain", "Mcclure", "Mcconnell", "Mccormick", "Mccoy", "Mccray", "Mccullough"
        , "Mcdaniel", "Mcdonald", "Mcdowell", "Mcfadden", "Mcfarland", "Mcgee", "Mcgowan", "Mcguire", "Mcintosh",
        "Mcintyre", "Mckay", "Mckee", "Mckenzie", "Mckinney", "Mcknight", "Mclaughlin", "Mclean", "Mcleod", "Mcmahon",
        "Mcmillan", "Mcneil", "Mcpherson", "Meadows", "Medina", "Mejia", "Melendez", "Melton", "Mendez", "Mendoza",
        "Mercado", "Mercer", "Merrill", "Merritt", "Meyer", "Meyers", "Michael", "Middleton", "Miles", "Miller", "Mills"
        , "Miranda", "Mitchell", "Molina", "Monroe", "Montgomery", "Montoya", "Moody", "Moon", "Mooney", "Moore",
        "Morales", "Moran", "Moreno", "Morgan", "Morin", "Morris", "Morrison", "Morrow", "Morse", "Morton", "Moses",
        "Mosley", "Moss", "Mueller", "Mullen", "Mullins", "Munoz", "Murphy", "Murray", "Myers", "Nash", "Navarro",
        "Neal", "Nelson", "Newman", "Newton", "Nguyen", "Nichols", "Nicholson", "Nielsen", "Nieves", "Nixon", "Noble",
        "Noel", "Nolan", "Norman", "Norris", "Norton", "Nunez", "O'brien", "O'connor", "O'donnell", "O'neal", "O'neil",
        "O'neill", "Ochoa", "Odom", "Oliver", "Olsen", "Olson", "Orr", "Ortega", "Ortiz", "Osborn", "Osborne", "Owen",
        "Owens", "Pace", "Pacheco", "Padilla", "Page", "Palmer", "Park", "Parker", "Parks", "Parrish", "Parsons", "Pate"
        , "Patel", "Patrick", "Patterson", "Patton", "Paul", "Payne", "Pearson", "Peck", "Pena", "Pennington", "Perez",
        "Perkins", "Perry", "Peters", "Petersen", "Peterson", "Petty", "Phelps", "Phillips", "Pickett", "Pierce",
        "Pittman", "Pitts", "Pollard", "Poole", "Pope", "Porter", "Potter", "Potts", "Powell", "Powers", "Pratt",
        "Preston", "Price", "Prince", "Pruitt", "Puckett", "Pugh", "Quinn", "Ramirez", "Ramos", "Ramsey", "Randall",
        "Randolph", "Rasmussen", "Ratliff", "Ray", "Raymond", "Reed", "Reese", "Reeves", "Reid", "Reilly", "Reyes",
        "Reynolds", "Rhodes", "Rice", "Rich", "Richard", "Richards", "Richardson", "Richmond", "Riddle", "Riggs",
        "Riley", "Rios", "Rivas", "Rivera", "Rivers", "Roach", "Robbins", "Roberson", "Roberts", "Robertson", "Robinson"
        , "Robles", "Rodgers", "Rodriguez", "Rodriquez", "Rogers", "Rojas", "Rollins", "Roman", "Romero", "Rosa",
        "Rosales", "Rosario", "Rose", "Ross", "Roth", "Rowe", "Rowland", "Roy", "Ruiz", "Rush", "Russell", "Russo",
        "Rutledge", "Ryan", "Salas", "Salazar", "Salinas", "Sampson", "Sanchez", "Sanders", "Sandoval", "Sanford",
        "Santana", "Santiago", "Santos", "Sargent", "Saunders", "Savage", "Sawyer", "Schmidt", "Schneider", "Schroeder",
        "Schultz", "Schwartz", "Scott", "Sears", "Sellers", "Serrano", "Sexton", "Shaffer", "Shannon", "Sharp", "Sharpe"
        , "Shaw", "Shelton", "Shepard", "Shepherd", "Sheppard", "Sherman", "Shields", "Short", "Silva", "Simmons",
        "Simon", "Simpson", "Sims", "Singleton", "Skinner", "Slater", "Sloan", "Small", "Smith", "Snider", "Snow",
        "Snyder", "Solis", "Solomon", "Sosa", "Soto", "Sparks", "Spears", "Spence", "Spencer", "Stafford", "Stanley",
        "Stanton", "Stark", "Steele", "Stein", "Stephens", "Stephenson", "Stevens", "Stevenson", "Stewart", "Stokes",
        "Stone", "Stout", "Strickland", "Strong", "Stuart", "Suarez", "Sullivan", "Summers", "Sutton", "Swanson",
        "Sweeney", "Sweet", "Sykes", "Talley", "Tanner", "Tate", "Taylor", "Terrell", "Terry", "Thomas", "Thompson",
        "Thornton", "Tillman", "Todd", "Torres", "Townsend", "Tran", "Travis", "Trevino", "Trujillo", "Tucker", "Turner"
        , "Tyler", "Tyson", "Underwood", "Valencia", "Valentine", "Valenzuela", "Vance", "Vargas", "Vasquez", "Vaughan",
        "Vaughn", "Vazquez", "Vega", "Vincent", "Vinson", "Wade", "Wagner", "Walker", "Wall", "Wallace", "Waller",
        "Walls", "Walsh", "Walter", "Walters", "Walton", "Ward", "Ware", "Warner", "Warren", "Washington", "Waters",
        "Watkins", "Watson", "Watts", "Weaver", "Webb", "Weber", "Webster", "Weeks", "Weiss", "Welch", "Wells", "West",
        "Wheeler", "Whitaker", "White", "Whitehead", "Whitfield", "Whitley", "Whitney", "Wiggins", "Wilcox", "Wilder",
        "Wiley", "Wilkerson", "Wilkins", "Wilkinson", "William", "Williams", "Williamson", "Willis", "Wilson", "Winters"
        , "Wise", "Witt", "Wolf", "Wolfe", "Wong", "Wood", "Woodard", "Woods", "Woodward", "Wooten", "Workman", "Wright"
        , "Wyatt", "Wynn", "Yang", "Yates", "York", "Young", "Zamora", "Zimmerman"};

        private static string[] nm7 =  {"Aaren", "Addison", "Aiden", "Alex", "Alexis", "Ali", "Angel", "Ash", "Ashley", "Ashton", "Aubrey",
        "Avery", "Bailey", "Bennie", "Bev", "Billie", "Billy", "Blair", "Blake", "Bret", "Brett", "Brice", "Brook",
        "Brynn", "Caden", "Cameron", "Carmen", "Carol", "Casey", "Charlie", "Chris", "Clem", "Cory", "Dane", "Danni",
        "Danny", "Denny", "Drew", "Eli", "Elliot", "Emerson", "Erin", "Fran", "Frankie", "Franky", "Gabby", "Gabe",
        "Gail", "Gale", "Gene", "Glen", "Glenn", "Haiden", "Harley", "Harper", "Hayden", "Jackie", "Jaden", "Jaime",
        "Jamie", "Jess", "Jesse", "Jessie", "Jo", "Jody", "Jordan", "Jude", "Justice", "Kai", "Kerry", "Kiran", "Kit",
        "Kris", "Lane", "Lee", "Leigh", "Lesley", "Leslie", "Logan", "Lynn", "Maddox", "Marley", "Mason", "Mel", "Mell",
        "Morgan", "Nicky", "Noel", "Phoenix", "Quinn", "Ray", "Raylee", "Reed", "Reggie", "Rene", "Riley", "River",
        "Robin", "Rory", "Rowan", "Rudy", "Ryan", "Sam", "Sammy", "Shay", "Sidney", "Silver", "Skye", "Skylar", "Skyler"
        , "Steff", "Tanner", "Taylor", "Terry", "Tyler", "Val", "Vic", "Will", "Willy"};
    }
}