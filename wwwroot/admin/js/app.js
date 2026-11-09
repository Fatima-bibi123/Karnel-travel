
document.addEventListener("DOMContentLoaded",()=>{
 const path=location.pathname.split("/").pop()||"index.html";
 document.querySelectorAll(".nav a").forEach(a=>{if(a.getAttribute("href")===path)a.classList.add("active")});
 const menu=document.querySelector(".menu-btn"), sidebar=document.querySelector(".sidebar");
 if(menu)menu.addEventListener("click",()=>sidebar.classList.toggle("open"));
 document.querySelectorAll("[data-toast]").forEach(b=>b.addEventListener("click",()=>showToast(b.dataset.toast||"Action completed")));
 const global=document.querySelector("#globalSearch");
 if(global)global.addEventListener("input",()=>filterRows(global.value));
 const page=document.querySelector("#pageSearch");
 if(page)page.addEventListener("input",()=>filterRows(page.value));
 document.querySelectorAll(".delete-row").forEach(btn=>btn.addEventListener("click",()=>{
   if(confirm("Delete this record?")){btn.closest("tr").remove();showToast("Record deleted")}
 }));
 document.querySelectorAll(".pagination button").forEach(btn=>btn.addEventListener("click",()=>{
   document.querySelectorAll(".pagination button").forEach(x=>x.classList.remove("active"));
   if(btn.innerText!=="‹"&&btn.innerText!=="›")btn.classList.add("active");
 }));
});
function filterRows(value){
 const q=(value||"").toLowerCase();
 document.querySelectorAll("tbody tr").forEach(row=>row.style.display=row.innerText.toLowerCase().includes(q)?"":"none");
}
function showToast(msg){
 const t=document.querySelector(".toast");if(!t)return;
 t.textContent=msg;t.style.display="block";clearTimeout(window.tt);
 window.tt=setTimeout(()=>t.style.display="none",2200);
}
