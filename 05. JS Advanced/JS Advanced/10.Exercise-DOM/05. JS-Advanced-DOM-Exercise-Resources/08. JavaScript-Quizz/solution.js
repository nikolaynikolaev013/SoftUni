function solve() {
  let step = 0;
  let right = 0;
  checkAnswer();

  function checkAnswer(){
    let currSection = document.querySelectorAll('section')[step];
    let buttons = currSection.querySelectorAll('.answer-text');
    
    for (const button of buttons) {
      button.addEventListener('click', ()=>{
        if (step === 0) {
          if (button.parentElement.parentElement.className === 'quiz-answer low-value') {
            right++;
          }
          step++;
        }else if (step === 1) {
          if (button.parentElement.parentElement.className === 'quiz-answer high-value') {
            right++;
          }
          step++
        }else if (step === 2) {
          if (button.parentElement.parentElement.className === 'quiz-answer low-value') {
            right++;
          }
          step++
        }

        currSection.classList.add("hidden");
        currSection.style.display = 'none';
        if (step < 3) {
          let nextSection = document.querySelectorAll('section')[step];
          nextSection.classList.remove("hidden");
          nextSection.style.display = "block";
          checkAnswer();
        }else{
          printResults();
        }
      });
    }

    function printResults(){
      let resultsUlElement = document.querySelector('#results');
      resultsUlElement.style.display = 'block';
      resultsUlElement.querySelector('h1').textContent = right === 3 ? "You are recognized as top JavaScript fan!" : `You have ${right} right answers`;
    }
  }
}
