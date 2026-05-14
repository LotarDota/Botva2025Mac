// ========== LEVEL COLORS ==========
const LV_COLORS = [
  '#8b949e', // 0 — серый
  '#3fb950', // I — зелёный
  '#58a6ff', // II — синий
  '#bc8cff', // III — фиолетовый
  '#f0883e', // IV — оранжевый
  '#ff7b72'  // V — красный
];

// ========== COSMO LEVEL SWITCHER ==========
document.querySelectorAll('.cosmo-slot').forEach(slot => {
  const ids = slot.dataset.ids.split(',');
  const img = slot.querySelector('img');
  const idLabel = slot.querySelector('.cosmo-ids');
  const lvSpans = slot.querySelectorAll('.lv');

  lvSpans.forEach((lv, idx) => {
    lv.onclick = e => {
      e.stopPropagation();
      lvSpans.forEach(l => l.classList.remove('active'));
      lv.classList.add('active');

      const itemId = ids[idx];
      const baseId = ids[0];
      img.src = `https://i.botva.ru/images/items/${baseId}s.jpg`;
      idLabel.textContent = `ID ${itemId}`;

      const color = LV_COLORS[idx];
      slot.style.borderColor = color;
      slot.style.borderTopColor = color;
      slot.style.boxShadow = `0 0 16px ${color}44, inset 0 0 8px ${color}22`;
      img.style.borderColor = color;
    };
  });
});

// ========== MODAL ==========
const modal = document.getElementById('modal');
document.getElementById('modalClose').onclick = () => modal.classList.remove('active');
modal.onclick = e => { if (e.target === modal) modal.classList.remove('active') };
document.addEventListener('keydown', e => { if (e.key === 'Escape') modal.classList.remove('active') });

function showModal(name, id, desc, imgUrl) {
  document.getElementById('modalTitle').textContent = name;
  document.getElementById('modalId').textContent = id;
  document.getElementById('modalDesc').textContent = desc || 'Описание не найдено';
  const imgDiv = document.getElementById('modalImg');
  imgDiv.innerHTML = imgUrl ? `<img src="${imgUrl}" alt="${name}" onerror="this.style.display='none'">` : '';
  modal.classList.add('active');
}

// ========== STALKERUS ==========
const stalkerus = [
  { id: 2752, name: 'Кислый Эолан' },
  { id: 2753, name: 'Вишневый Люмион' },
  { id: 2754, name: 'Лимонный Фростиан' },
  { id: 2755, name: 'Мятный Сильван' },
  { id: 2756, name: 'Малиновый Эльрион' },
  { id: 2757, name: 'Апельсиновый Нивиан' },
  { id: 2758, name: 'Ежевичный Корвиан' },
  { id: 2759, name: 'Голубичный Велиан' },
  { id: 2760, name: 'Радужный Стультан' }
];
const stGrid = document.getElementById('stalkerusGrid');
stalkerus.forEach(s => {
  const item = SPRING_ITEMS.find(i => i.id === s.id);
  const card = document.createElement('div');
  card.className = 'stalk-card' + (s.id === 2760 ? ' main' : '');
  const img = `https://i.botva.ru/images/items/${s.id}s.jpg`;
  card.innerHTML = `<img src="${img}" alt="${s.name}" onerror="this.style.display='none'"><h4>${s.name}</h4>`;
  card.onclick = () => showModal(s.name, `item_${s.id}`, item ? item.d : '', img);
  stGrid.appendChild(card);
});

// ========== ALL ITEMS ==========
const grid = document.getElementById('itemsGrid');
const searchInput = document.getElementById('searchInput');

function renderItems(query) {
  grid.innerHTML = '';
  const q = (query || '').toLowerCase();
  const filtered = q ? SPRING_ITEMS.filter(i => i.n.toLowerCase().includes(q)) : SPRING_ITEMS;
  filtered.forEach(item => {
    const card = document.createElement('div');
    card.className = 'item-card';
    const imgSrc = item.img || `https://g1.botva.ru/i/global/icon/promo200.png`;
    card.innerHTML = `<img src="${imgSrc}" alt="${item.n}" onerror="this.src='https://g1.botva.ru/i/global/icon/promo200.png'">
      <div><div class="iname">${item.n}</div><div class="iid">item_${item.id}</div></div>`;
    card.onclick = () => showModal(item.n, `item_${item.id}`, item.d, item.img);
    grid.appendChild(card);
  });
}
renderItems();

let timer;
searchInput.oninput = e => {
  clearTimeout(timer);
  timer = setTimeout(() => renderItems(e.target.value.trim()), 200);
};

// ========== ARTIFACTS ==========
const artIds = [2804, 2805, 2806, 2807, 2808];
const artGrid = document.getElementById('artifactsGrid');
artIds.forEach(id => {
  const item = SPRING_ITEMS.find(i => i.id === id);
  if (!item) return;
  const card = document.createElement('div');
  card.className = 'art-card';
  const img = item.img || '';
  card.innerHTML = `<img src="${img}" alt="${item.n}" onerror="this.style.display='none'">
    <div><div class="aid">item_${item.id}</div><h4>${item.n}</h4><p>${item.d ? item.d.slice(0, 150) : ''}</p></div>`;
  card.onclick = () => showModal(item.n, `item_${item.id}`, item.d, item.img);
  artGrid.appendChild(card);
});

// ========== SMOOTH SCROLL ==========
document.querySelectorAll('a[href^="#"]').forEach(a => {
  a.onclick = e => {
    e.preventDefault();
    const t = document.querySelector(a.getAttribute('href'));
    if (t) t.scrollIntoView({ behavior: 'smooth' });
  };
});
