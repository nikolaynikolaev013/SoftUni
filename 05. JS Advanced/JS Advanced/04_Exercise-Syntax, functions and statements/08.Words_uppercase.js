function toUpper(words){

    let splittedWords = words.toUpperCase().replace(/[.,\/#!?$%\^&\*;:{}=\-_`~()]/g,"").split(' ');

    console.log(splittedWords.join(', '));

    //console.log(words.toUpperCase().join(','));
}

toUpper('hello');