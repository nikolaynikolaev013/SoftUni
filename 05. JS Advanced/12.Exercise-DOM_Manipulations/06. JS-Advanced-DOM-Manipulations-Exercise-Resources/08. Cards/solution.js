function solve() {
   let player1DivElement = document.querySelector('#player1Div');
   let player1SpanElement = document.querySelector('#result').children[0];

   let player2DivElement = document.querySelector('#player2Div');
   let player2SpanElement = document.querySelector('#result').children[2];

   let tempCard1;
   let tempCard2;

   player1DivElement.addEventListener('click', (e) => {
      if (e.target != e.currentTarget) {
         e.target.src = 'images/whiteCard.jpg';
         tempCard1 = e.target;
         player1SpanElement.textContent = `${tempCard1.name}`;
         
         if (tempCard2 != undefined) {
            checkCards();
         }
      }
   });

   player2DivElement.addEventListener('click', (e) => {
      if (e.target != e.currentTarget) {
         e.target.src = 'images/whiteCard.jpg';
         tempCard2 = e.target;
         player2SpanElement.textContent = `${tempCard2.name}`;
         
         if (tempCard1 != undefined) {
            checkCards();
         }
      }
   });
   function checkCards(){
      let historyElement = document.querySelector('#history');

      let card1Value = Number(tempCard1.name);
      let card2Value = Number(tempCard2.name);

      let winner = '2px solid green';
      let loser = '2px solid red';

      tempCard1.style.border = card1Value < card2Value ? loser : winner;
      tempCard2.style.border = card1Value < card2Value ? winner : loser;

      let msg = `[${card1Value} vs ${card2Value}] `;
      historyElement.textContent += msg;
      tempCard1 = undefined;
      tempCard2 = undefined;
   }
}