// ========== PARTICLE BACKGROUND ==========
const canvas = document.getElementById('particles');
const ctx = canvas.getContext('2d');
let particles = [];
const PARTICLE_COUNT = 60;

function resizeCanvas() {
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;
}
resizeCanvas();
window.addEventListener('resize', resizeCanvas);

class Particle {
    constructor() {
        this.reset();
    }
    reset() {
        this.x = Math.random() * canvas.width;
        this.y = Math.random() * canvas.height;
        this.size = Math.random() * 2 + 0.5;
        this.speedX = (Math.random() - 0.5) * 0.3;
        this.speedY = (Math.random() - 0.5) * 0.3;
        this.opacity = Math.random() * 0.4 + 0.1;
        this.hue = Math.random() > 0.5 ? 45 : 30;
    }
    update() {
        this.x += this.speedX;
        this.y += this.speedY;
        if (this.x < 0 || this.x > canvas.width || this.y < 0 || this.y > canvas.height) {
            this.reset();
        }
    }
    draw() {
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2);
        ctx.fillStyle = `hsla(${this.hue}, 80%, 60%, ${this.opacity})`;
        ctx.fill();
    }
}

for (let i = 0; i < PARTICLE_COUNT; i++) {
    particles.push(new Particle());
}

function animateParticles() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    particles.forEach(p => {
        p.update();
        p.draw();
    });
    requestAnimationFrame(animateParticles);
}
animateParticles();

// ========== COUNTER ANIMATION ==========
function animateCounters() {
    const counters = document.querySelectorAll('.stat-num');
    counters.forEach(counter => {
        const target = parseInt(counter.getAttribute('data-count'));
        const duration = 2000;
        const step = target / (duration / 16);
        let current = 0;
        const timer = setInterval(() => {
            current += step;
            if (current >= target) {
                counter.textContent = target.toLocaleString();
                clearInterval(timer);
            } else {
                counter.textContent = Math.floor(current).toLocaleString();
            }
        }, 16);
    });
}

// ========== SCROLL ANIMATIONS (AOS-like) ==========
const observerOptions = {
    threshold: 0.1,
    rootMargin: '0px 0px -50px 0px'
};

const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            const delay = parseInt(entry.target.getAttribute('data-delay') || 0);
            setTimeout(() => {
                entry.target.classList.add('aos-animate');
            }, delay);
        }
    });
}, observerOptions);

document.querySelectorAll('[data-aos]').forEach(el => observer.observe(el));

// ========== STICKY NAV ==========
const nav = document.getElementById('mainNav');
const hero = document.getElementById('hero');

window.addEventListener('scroll', () => {
    if (window.scrollY > hero.offsetHeight - 100) {
        nav.classList.add('visible');
    } else {
        nav.classList.remove('visible');
    }
});

// Active nav link
const sections = document.querySelectorAll('.section');
const navLinks = document.querySelectorAll('.nav-links a');

window.addEventListener('scroll', () => {
    let current = '';
    sections.forEach(section => {
        const sectionTop = section.offsetTop - 100;
        if (window.scrollY >= sectionTop) {
            current = section.getAttribute('id');
        }
    });
    navLinks.forEach(link => {
        link.classList.remove('active');
        if (link.getAttribute('href') === `#${current}`) {
            link.classList.add('active');
        }
    });
});

// ========== TRIGGER COUNTERS ON SCROLL ==========
let countersStarted = false;
const heroObserver = new IntersectionObserver((entries) => {
    if (entries[0].isIntersecting && !countersStarted) {
        countersStarted = true;
        animateCounters();
    }
}, { threshold: 0.3 });
heroObserver.observe(document.querySelector('.hero-stats'));

// ========== NEWEST ITEMS DATA ==========
const newestItems = [
    { id: 2700, name: "Майский мимик", img: "2700s.jpg" },
    { id: 2701, name: "Хитрый осьминог", img: "2701s.jpg" },
    { id: 2702, name: "Затонувший сундук", img: "2541s.jpg" },
    { id: 2703, name: "Меха-крылья", img: "2703s.jpg" },
    { id: 2704, name: "Меха-пружины", img: "2704s.jpg" },
    { id: 2705, name: "Треуголка капитана Клюва", img: "2705s.jpg" },
    { id: 2706, name: "Сундук предков", img: "2706s.jpg" },
    { id: 2707, name: "Дьявольский шелом", img: "2707s.jpg" },
    { id: 2708, name: "Глубинный кромсатель", img: "2708s.jpg" },
    { id: 2709, name: "Удушающие хваты", img: "2709s.jpg" },
    { id: 2710, name: "Доспех Морского дьявола", img: "2710s.jpg" },
    { id: 2711, name: "Фрагмент Дьявольского шелома", img: "2711s.jpg" },
    { id: 2712, name: "Фрагмент Глубинного кромсателя", img: "2712s.jpg" },
    { id: 2713, name: "Фрагмент Удушающих хватов", img: "2713s.jpg" },
    { id: 2714, name: "Фрагмент доспеха Морского дьявола", img: "2714s.jpg" },
    { id: 2715, name: "Мститель", img: "2715s.jpg" },
    { id: 2716, name: "Костяной барабан", img: "2716s.jpg" },
    { id: 2717, name: "Восковые мелки", img: "2717s.jpg" },
    { id: 2718, name: "Блошиный кристалл", img: "2718s.jpg" },
    { id: 2719, name: "Блошиный сундук", img: "2621s.jpg" },
    { id: 2720, name: "Редкий сундук", img: "2720s.jpg" },
    { id: 2721, name: "Эпический сундук", img: "2721s.jpg" },
    { id: 2722, name: "Легендарный сундук", img: "2722s.jpg" },
    { id: 2723, name: "Чертовы рожки", img: "2723s.jpg" },
    { id: 2724, name: "Чертов хвостик", img: "2724s.jpg" },
    { id: 2725, name: "Чертова молотилка", img: "2725s.jpg" },
    { id: 2728, name: "Звездокамень", img: "2728s.jpg" },
    { id: 2729, name: "Золотая рыбка", img: "2729s.jpg" },
    { id: 2730, name: "Подарок на 17-летие Ботвы", img: "2730s.jpg" },
    { id: 2731, name: "Кусочек праздничной аватарки", img: "2731s.jpg" },
    { id: 2733, name: "Заячий шарф", img: "2733s.jpg" },
    { id: 2734, name: "Ноябрьский ларец", img: "2734s.jpg" },
    { id: 2736, name: "Снежный големчик", img: "2736s.jpg" },
    { id: 2737, name: "Колдунская сосучка", img: "2737s.jpg" },
    { id: 2738, name: "Сабля Морозуса", img: "2738s.jpg" },
    { id: 2739, name: "Икарусов мешочек", img: "2739s.jpg" },
    { id: 2740, name: "Снежная калимба", img: "2740s.jpg" },
    { id: 2741, name: "Мандавилка", img: "2741s.jpg" },
    { id: 2742, name: "Стишок «Задорная колядка»", img: "2742s.jpg" },
    { id: 2743, name: "Стишок «Веселая прибаутка»", img: "2743s.jpg" },
    { id: 2744, name: "Стишок «Забавная шутка»", img: "2744s.jpg" },
    { id: 2745, name: "Стишок «Проникновенная ода»", img: "2745s.jpg" },
    { id: 2746, name: "Стишок «Заманчивая песня»", img: "2746s.jpg" },
    { id: 2747, name: "Стишок «Задумчивый сонет»", img: "2747s.jpg" },
    { id: 2748, name: "Стишок «Мудрое двустишие»", img: "2748s.jpg" },
    { id: 2749, name: "Стишок «Чудная загадка»", img: "2749s.jpg" },
    { id: 2750, name: "Золотой Стих Клеверландии", img: "2750s.jpg" },
    { id: 2751, name: "Глазастая сударыня", img: "2751s.jpg" },
    { id: 2752, name: "Кислый Эолан", img: "2752s.jpg" },
    { id: 2753, name: "Вишневый Люмион", img: "2753s.jpg" },
    { id: 2754, name: "Лимонный Фростиан", img: "2754s.jpg" },
    { id: 2755, name: "Мятный Сильван", img: "2755s.jpg" },
    { id: 2756, name: "Малиновый Эльрион", img: "2756s.jpg" },
    { id: 2757, name: "Апельсиновый Нивиан", img: "2757s.jpg" },
    { id: 2758, name: "Ежевичный Корвиан", img: "2758s.jpg" },
    { id: 2759, name: "Голубичный Велиан", img: "2759s.jpg" },
    { id: 2760, name: "Радужный Стультан", img: "2760s.jpg" },
    { id: 2761, name: "Свечи желаний", img: "2761s.jpg" },
    { id: 2763, name: "Зимний мимик", img: "2763s.jpg" },
    { id: 2765, name: "Квантовый сундук", img: "2765s.jpg" },
    { id: 2766, name: "Фрагментарный сундук", img: "2766s.jpg" },
    { id: 2767, name: "УраНовый сундук", img: "2767s.jpg" },
    { id: 2804, name: "Ревун", img: "2804s.jpg" },
    { id: 2805, name: "Вскрывашка консерв", img: "2805s.jpg" },
    { id: 2806, name: "Вонючка", img: "2806s.jpg" },
    { id: 2807, name: "Плюмаж достоинства", img: "2807s.jpg" },
    { id: 2808, name: "Пика точёная", img: "2808s.jpg" },
];

// ========== RENDER ITEMS ==========
const itemsGrid = document.getElementById('itemsGrid');
if (itemsGrid) {
    newestItems.forEach(item => {
        const card = document.createElement('div');
        card.className = 'item-card';
        card.setAttribute('data-aos', 'fade-up');
        card.innerHTML = `
            <img src="https://i.botva.ru/i/items/${item.img}" alt="${item.name}" 
                 onerror="this.src='https://i.botva.ru/i/global/icon/promo200.png'">
            <div>
                <div class="item-name">${item.name}</div>
                <div class="item-num">item_${item.id}</div>
            </div>
        `;
        itemsGrid.appendChild(card);
    });

    // Re-observe dynamically added items
    itemsGrid.querySelectorAll('[data-aos]').forEach(el => observer.observe(el));
}

// ========== SMOOTH SCROLL ==========
document.querySelectorAll('a[href^="#"]').forEach(link => {
    link.addEventListener('click', e => {
        e.preventDefault();
        const target = document.querySelector(link.getAttribute('href'));
        if (target) {
            target.scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
    });
});
