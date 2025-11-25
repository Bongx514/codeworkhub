const board = document.getElementById("board");
const difficultySelect = document.getElementById("difficulty");
const timerText = document.getElementById("timer");
const movesText = document.getElementById("moves");
const winModal = document.getElementById("winModal");

let timer, movesLeft, timeLeft, firstCard, lock = false;

const cardIcons = [
    "fa-star", "fa-bolt", "fa-heart", "fa-ghost",
    "fa-moon", "fa-sun" // 6 pairs for 12 cards
];

function shuffle(array) {
    return array.sort(() => Math.random() - 0.5);
}

function startGame() {
    const level = difficultySelect.value;

    if (level === "beginner") { movesLeft = 30; timeLeft = 120; }
    if (level === "intermediate") { movesLeft = 24; timeLeft = 100; }
    if (level === "expert") { movesLeft = 18; timeLeft = 80; }
    if (level === "einstein") {
        movesLeft = 12; timeLeft = 60;
        document.getElementById("flipGame")
            .classList.replace("bg-[#0d1330]", "bg-red-950");
    }

    movesText.textContent = movesLeft;
    timerText.textContent = timeLeft + "s";

    generateCards();
    startTimer();
}

document.getElementById("startGame").addEventListener("click", startGame);

function startTimer() {
    timer = setInterval(() => {
        timeLeft--;
        timerText.textContent = timeLeft + "s";

        if (timeLeft <= 0 || movesLeft <= 0) {
            location.reload();
        }
    }, 1000);
}

function generateCards() {
    board.innerHTML = "";
    const gameCards = shuffle([...cardIcons, ...cardIcons]);

    gameCards.forEach(icon => {
        const card = document.createElement("div");
        card.className = "card bg-[#11214a] border border-cyan-500 rounded-xl aspect-square flex justify-center items-center text-3xl cursor-pointer transition-transform";
        card.dataset.icon = icon;
        card.innerHTML = `<i class="fa-solid ${icon} hidden"></i>`;

        card.addEventListener("click", () => flipCard(card));
        board.appendChild(card);
    });
}

function flipCard(card) {
    if (lock || !card) return;

    card.classList.add("bg-cyan-700");
    card.querySelector("i").classList.remove("hidden");

    if (!firstCard) {
        firstCard = card;
        return;
    }

    movesLeft--;
    movesText.textContent = movesLeft;

    if (card.dataset.icon === firstCard.dataset.icon) {
        firstCard = null;
        checkWin();
    } else {
        lock = true;
        setTimeout(() => {
            card.classList.remove("bg-cyan-700");
            card.querySelector("i").classList.add("hidden");

            firstCard.classList.remove("bg-cyan-700");
            firstCard.querySelector("i").classList.add("hidden");

            firstCard = null;
            lock = false;
        }, 700);
    }
}

function checkWin() {
    if ([...document.querySelectorAll(".card i.hidden")].length === 0) {
        clearInterval(timer);
        winModal.classList.remove("hidden");
    }
}
