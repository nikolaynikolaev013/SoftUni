function checkIfSpeeding(speed, area){
    
    let maxAllowedSpeed;

    switch (area){
        case "motorway":
            maxAllowedSpeed = 130;
            break;
        case "interstate":
            maxAllowedSpeed = 90;
            break;
        case "city":
            maxAllowedSpeed = 50;
            break;
        case "residential":
            maxAllowedSpeed = 20;
            break;
    }

    let diff = speed - maxAllowedSpeed;
    let output;
    
    if(diff > 0){
        if(diff <= 20){
         output = 'speeding';   
        }
        else if (diff <= 40){
            output = 'excessive speeding';
        }
        else{
            output = 'reckless driving';
        }
    }

    if(output){
        console.log(output);
    }
}

checkIfSpeeding(21, 'residential');