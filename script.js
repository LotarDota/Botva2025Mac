// ========== PARTICLES ==========
const canvas = document.getElementById('particles');
const ctx = canvas.getContext('2d');
function resize(){canvas.width=innerWidth;canvas.height=innerHeight}
resize(); addEventListener('resize',resize);
const pts=[];
for(let i=0;i<50;i++) pts.push({x:Math.random()*canvas.width,y:Math.random()*canvas.height,
  s:Math.random()*2+.5,dx:(Math.random()-.5)*.3,dy:(Math.random()-.5)*.3,
  o:Math.random()*.3+.1,h:Math.random()>.5?45:220});
(function anim(){
  ctx.clearRect(0,0,canvas.width,canvas.height);
  pts.forEach(p=>{p.x+=p.dx;p.y+=p.dy;
    if(p.x<0||p.x>canvas.width||p.y<0||p.y>canvas.height){p.x=Math.random()*canvas.width;p.y=Math.random()*canvas.height}
    ctx.beginPath();ctx.arc(p.x,p.y,p.s,0,Math.PI*2);ctx.fillStyle=`hsla(${p.h},70%,60%,${p.o})`;ctx.fill()});
  requestAnimationFrame(anim)
})();

// ========== COUNTER ==========
let started=false;
const statsObs=new IntersectionObserver(e=>{
  if(e[0].isIntersecting&&!started){started=true;
    document.querySelectorAll('.stat-n').forEach(el=>{
      const t=+el.dataset.count;let c=0;const step=t/(2000/16);
      const iv=setInterval(()=>{c+=step;if(c>=t){el.textContent=t.toLocaleString();clearInterval(iv)}
        else el.textContent=Math.floor(c).toLocaleString()},16)})}
},{threshold:.3});
statsObs.observe(document.querySelector('.hero-stats'));

// ========== NAV ==========
const nav=document.getElementById('topnav');
const hero=document.getElementById('hero');
addEventListener('scroll',()=>{nav.classList.toggle('show',scrollY>hero.offsetHeight-100)});
document.getElementById('burger').onclick=()=>document.getElementById('navLinks').classList.toggle('open');

// ========== SMOOTH SCROLL ==========
document.querySelectorAll('a[href^="#"]').forEach(a=>{
  a.onclick=e=>{e.preventDefault();const t=document.querySelector(a.getAttribute('href'));
    if(t)t.scrollIntoView({behavior:'smooth'});document.getElementById('navLinks').classList.remove('open')}});

// ========== MODAL ==========
const modal=document.getElementById('modal');
const modalClose=document.getElementById('modalClose');
function showModal(name,id,desc,imgUrl){
  document.getElementById('modalTitle').textContent=name;
  document.getElementById('modalId').textContent=id;
  document.getElementById('modalDesc').textContent=desc||'Описание не найдено';
  const imgDiv=document.getElementById('modalImg');
  if(imgUrl){imgDiv.innerHTML=`<img src="${imgUrl}" alt="${name}" onerror="this.style.display='none'">`}
  else{imgDiv.innerHTML=''}
  modal.classList.add('active');
}
modalClose.onclick=()=>modal.classList.remove('active');
modal.onclick=e=>{if(e.target===modal)modal.classList.remove('active')};
document.addEventListener('keydown',e=>{if(e.key==='Escape')modal.classList.remove('active')});

// ========== GUILDS ==========
const guilds=[
  {id:1,name:'Толстосумы',desc:'Торговая гильдия с льготами на аукционе. Уровень: 20+',battle:false},
  {id:2,name:'Железячники',desc:'Гильдия кузнецов для мастеров ковки. Уровень: 20+',battle:false},
  {id:3,name:'Шахтеры',desc:'Любители подземных работ и кристаллов. Уровень: 20+',battle:false},
  {id:4,name:'Работяги',desc:'Гильдия фермеров для любителей природы. Уровень: 20+',battle:false},
  {id:5,name:'Пернатый спецназ',desc:'Боевая гильдия',battle:true},
  {id:6,name:'Теневоды',desc:'Боевая гильдия',battle:true},
  {id:7,name:'Клыкуны',desc:'Боевая гильдия',battle:true},
  {id:8,name:'Краснокожие',desc:'Боевая гильдия',battle:true},
  {id:9,name:'Травники',desc:'Гильдия алхимиков. Уровень: 20+',battle:false},
  {id:10,name:'Летчики',desc:'Гильдия укротителей летунов. Уровень: 25+',battle:false},
  {id:11,name:'Устрашатели',desc:'Орден по изведению страшилок. Уровень: 25+',battle:false}
];
const guildsGrid=document.getElementById('guildsGrid');
guilds.forEach(g=>{
  const card=document.createElement('div');
  card.className='guild-card'+(g.battle?' battle':'');
  card.innerHTML=`<img src="https://i.botva.ru/images/guilds/Guild_${g.id}s.png" alt="${g.name}" 
    onerror="this.style.display='none'"><h4>${g.name}</h4><p>${g.desc}</p>`;
  card.onclick=()=>showModal(g.name,`guild_${g.id}`,g.desc,`https://i.botva.ru/images/guilds/Guild_${g.id}s.png`);
  guildsGrid.appendChild(card);
});

// ========== PETS ==========
const pets=[
  {id:1,name:'Шнырк',r:''},{id:2,name:'Царапка',r:''},{id:3,name:'Бобруйко',r:''},
  {id:4,name:'Спиношип',r:''},{id:5,name:'Енотка',r:''},{id:6,name:'Броневоз',r:''},
  {id:7,name:'Червячелло',r:''},{id:8,name:'Красный Червячелло',r:'rare'},
  {id:9,name:'Лисистричка',r:''},{id:10,name:'Красный Червячелло II',r:'rare'},
  {id:11,name:'Феникс',r:'legendary'},{id:12,name:'Обезьян',r:''},
  {id:13,name:'Хамелеоша',r:''},{id:14,name:'Хамелеоша II',r:''},{id:15,name:'Хамелеоша III',r:''},
  {id:16,name:'Дух древнего Червячелло',r:'epic'},
  {id:18,name:'Серый Мамонтоша',r:'epic'},{id:19,name:'Белый Мамонтоша',r:'epic'},
  {id:20,name:'Чёрный Мамонтоша',r:'legendary'},{id:21,name:'Красный Мамонтоша',r:'legendary'}
];
const petsGrid=document.getElementById('petsGrid');
pets.forEach(p=>{
  const card=document.createElement('div');
  card.className='pet-card'+(p.r?' '+p.r:'');
  const img=`https://i.botva.ru/images/items/Pet_${p.id}s.jpg`;
  card.innerHTML=`<img src="${img}" alt="${p.name}" onerror="this.style.display='none'">
    <h4>${p.name}</h4><span class="pet-id">#${p.id}</span>`;
  card.onclick=()=>showModal(p.name,`pet_${p.id}`,`Питомец (Летун) #${p.id}`,img);
  petsGrid.appendChild(card);
});

// ========== ALL ITEMS ==========
const ITEMS_PER_PAGE=100;
let currentCat='all';
let searchQuery='';
let displayedCount=0;

function getFiltered(){
  let list=ALL_ITEMS;
  if(currentCat!=='all') list=list.filter(i=>i.cat===currentCat);
  if(searchQuery) list=list.filter(i=>i.n.toLowerCase().includes(searchQuery));
  return list;
}

function renderItems(reset){
  const grid=document.getElementById('itemsGrid');
  const btn=document.getElementById('loadMore');
  if(reset){grid.innerHTML='';displayedCount=0}
  const filtered=getFiltered();
  const batch=filtered.slice(displayedCount,displayedCount+ITEMS_PER_PAGE);
  batch.forEach(item=>{
    const card=document.createElement('div');
    card.className='item-card';
    const imgHtml=item.img?`<img src="${item.img}" alt="${item.n}" onerror="this.src='https://g1.botva.ru/i/global/icon/promo200.png'">`
      :`<img src="https://g1.botva.ru/i/global/icon/promo200.png" alt="">`;
    card.innerHTML=`${imgHtml}<div><div class="iname">${item.n}</div><div class="iid">item_${item.id}</div></div>`;
    card.onclick=()=>showModal(item.n,`item_${item.id}`,item.d,item.img);
    grid.appendChild(card);
  });
  displayedCount+=batch.length;
  document.getElementById('itemsCount').textContent=`Показано ${displayedCount} из ${filtered.length}`;
  btn.style.display=displayedCount<filtered.length?'block':'none';
}

// Init items
renderItems(true);

// Load more
document.getElementById('loadMore').onclick=()=>renderItems(false);

// Search
let searchTimer;
document.getElementById('searchInput').oninput=e=>{
  clearTimeout(searchTimer);
  searchTimer=setTimeout(()=>{searchQuery=e.target.value.toLowerCase().trim();renderItems(true)},300);
};

// Filter buttons
document.getElementById('filterBtns').onclick=e=>{
  if(!e.target.classList.contains('fbtn'))return;
  document.querySelectorAll('.fbtn').forEach(b=>b.classList.remove('active'));
  e.target.classList.add('active');
  currentCat=e.target.dataset.cat;
  renderItems(true);
};

// ========== SCROLL ANIMATIONS ==========
const obs=new IntersectionObserver(entries=>{
  entries.forEach(e=>{if(e.isIntersecting)e.target.classList.add('show')})
},{threshold:.1,rootMargin:'0px 0px -40px 0px'});
document.querySelectorAll('[data-aos]').forEach(el=>obs.observe(el));
