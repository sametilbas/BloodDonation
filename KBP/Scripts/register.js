
function cambiar_bagisci() {
  document.querySelector('.cont_forms').className = "cont_forms cont_forms_active_bagisci";  
document.querySelector('.cont_form_bagisci').style.display = "block";
document.querySelector('.cont_form_hastane').style.opacity = "0";   
document.querySelector('.cont_form_kanmerkezi').style.opacity = "0";              
setTimeout(function(){  document.querySelector('.cont_form_bagisci').style.opacity = "1"; },400);   
setTimeout(function(){    document.querySelector('.cont_form_sign_up').style.display = "none";},200);
setTimeout(function(){    document.querySelector('.cont_form_kanmerkezi').style.display = "none";},200);  
  }

function cambiar_hastane(at) {
 document.querySelector('.cont_forms').className = "cont_forms cont_forms_active_hastane";
  document.querySelector('.cont_form_hastane').style.display = "block";
document.querySelector('.cont_form_bagisci').style.opacity = "0"; 
document.querySelector('.cont_form_kanmerkezi').style.opacity = "0";  
setTimeout(function(){  document.querySelector('.cont_form_hastane').style.opacity = "1";},100);  
setTimeout(function(){   document.querySelector('.cont_form_bagisci').style.display = "none";},400); 
setTimeout(function(){   document.querySelector('.cont_form_kanmerkezi').style.display = "none";},400);  
}    

function cambiar_kanmerkezi(at) {
  document.querySelector('.cont_forms').className = "cont_forms cont_forms_active_hastane";
   document.querySelector('.cont_form_kanmerkezi').style.display = "block";
 document.querySelector('.cont_form_bagisci').style.opacity = "0"; 
 document.querySelector('.cont_form_hastane').style.opacity = "0";  
 setTimeout(function(){  document.querySelector('.cont_form_kanmerkezi').style.opacity = "1";},100);  
 setTimeout(function(){   document.querySelector('.cont_form_bagisci').style.display = "none";},400); 
 setTimeout(function(){   document.querySelector('.cont_form_hastane').style.display = "none";},400);  
 }    

function ocultar_bagisci_hastane_kanmerkezi() {
document.querySelector('.cont_forms').className = "cont_forms";  
document.querySelector('.cont_form_hastane').style.opacity = "0";               
document.querySelector('.cont_form_bagisci').style.opacity = "0"; 
document.querySelector('.cont_form_kanmerkezi').style.opacity = "0"; 
setTimeout(function(){
document.querySelector('.cont_form_hastane').style.display = "none";
document.querySelector('.cont_form_bagisci').style.display = "none";
document.querySelector('.cont_form_kanmerkezi').style.display = "none";},500);  

  }