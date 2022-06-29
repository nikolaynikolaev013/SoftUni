function solve(...input){
    let counter = {};

    for (const arg in input) {
        let argType = typeof(input[arg]);
        if (!counter[argType]) {
            counter[argType] = 0;
        }
        counter[argType]++;

        console.log(`${argType}: ${input[arg]}`);
    }

    Object.keys(counter).sort((a,b) => counter[b] - counter[a]).forEach(x => console.log(`${x} = ${counter[x]}`));

}

solve('cat', 42, function () { console.log('Hello world!'); });
