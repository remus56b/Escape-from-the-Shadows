# Escape-from-the-Shadows - proiect IMR  

## Table of Contents
* [Team](#team)
* [Story](#story)
* [Research](#research)    
* [Progress](#progress)  

## Team  
* Băcăoanu Remus (B2)  
* Burcă Theodor (B2)  
* Cernat George Lucian (B2)  
* Muraru Cosmin-Alexandru (B2)

## Story
In jocul "Escape from the Shadows: A Haunted Journey", jucătorul este introdus într-o experiență înfricoșătoare, ghidat de vocea unui copil în timp ce explorează o casă bântuită.  
Descoperind o scrisoare tulburătoare în casa bântuită, jucătorul este teleportat într-un spital misterios. Acolo, descoperă cheia pentru cufărul din casa bântuită.  
Întorcându-se în casa prin teleportare, jucătorul găsește cufărul care conține inima copilului. În acest moment, dezvăluie informații cutremurătoare: părinții copilului, fiind medici paranoici, au crezut că fiul lor este posedat și l-au supus unor tratamente inumane, care în final l-au omorât.  
Cufărul dezvăluie inima copilului, cheia pentru a pune capăt bântuirii. Jucătorul deschide o ușă secretă, scoate inima și, pentru a ridica blestemul și a aduce pacea, o îngroapă într-un loc special din apropiere.
Prin această acțiune, jucătorul reușește să aducă eliberarea și să pună capăt bântuirii casei, încheind astfel această experiență înspăimântătoare, dezvăluind și tragicul adevăr despre soarta copilului și a părinților săi.  
Pe măsură ce jucătorul explorează și caută cheia, trebuie să fie atent la jumpscare-uri și monștri care pot apărea în cale. Dacă este prins de acești monștri, jocul se termina.  

   
## Research  
State of the art:  
https://docs.google.com/document/d/1ysYDn8BCYkhXICMMVC4dU5SEeswwE7hTc-Z8tnlw1qw/edit?usp=sharing 

Tema 5:  
https://docs.google.com/document/d/11B0Ko0HrHl-IjR3SF8KRO3pt3WxhZlOr_5ArVFyjAXc/edit#heading=h.bcldxwdefncd  

Link video week 7: https://www.youtube.com/watch?v=ZGocZSvKPm8&ab_channel=CosminMuraru   

Pana in saptamana 7, am finalizat povestea jocului si am decis care vor fi puzzle-urile. De asemenea, am reusit sa aducem in scena asset-urile principale de care vom avea nevoie: casa, subsolul spitalulul, majoritatea obiectelelor care fac parte din decor si monstrii.   
La partea de modelare, vom mai avea de facut cimitirul, unde va avea loc scena finala din joc (unde trebuie sa ingroape inima pentru a dezlega blestemul).  


## Progress  
> Pana in saptamana a 10-a, am reusit sa:  
> * am adaugat XR Interaction Manager in proiect  
> * am atasat mainile modelate personajului  
> * am creat, folosind AI, dialogul dintre jucator si fantoma copilului (toata povestea jocului)  
> * atunci cand jucatorul se apropie de Crawler (cand se atinge distanta minima), se activeaza jumpscare-ul Crawler-ului, si de asemenea se aude si un sunet creepy ("Peekaboo, I see you ... ")  
> * am adaugat sunete de fundal in joc: sunet de furtuna, tunete, vant puternic, scartait de usi, plansete etc..  
> * am realizat actiunea de grab a cheii ( obiectului rust_key)  
> * modificarea atributelor la incapere, cheie si raft din basement pentru a permite coliziunile si gravitatia.  


> Pana in saptamana a 11-a:  
> * am facut 'merge' la toate scenele intr-una: pana in aceasta saptamana am lucrat pe echipe la scene, iar acum scenele sunt gata, asa ca am combinat proiectele si le-am facut sa fie unul singur;  
> * am imbunatatit movement-ul player-ului: acum se misca mai rapid in joc (inainte avea viteza foarte mica si dura mult pentru a se deplasa);  
> * am adaugat RigidBody, BoxCollider si GrabInteractable pentru majoritatea obiectelor, pentru a simula un mediu mai realist;  
> * am adaugat o parte din dialogul personajului cu vocea copilului;  
> * am adaugat animatii la cufar si inima copilului;
> * am inceput sa lucram la teleportare;
> * am inceput sa lucram la componentele environment-ului si la felul cum player-ul interactioneaza cu el(permiterea coliziunii cu peretii);   


> Pana in saptamana a 12-a:    
> * am imbunatatit movement-ul player-ului;  
> * am actualizat interactiunea player-ului cu structura casei (mai sunt detalii de > modificat);  
> * am lucrat la teleportare (suntem in faza de testare);  
> * am adaugat scrisoarea care introduce playerul in poveste; de asemenea am introdus si logica interactiunii cu scrisoarea (cand se apropie de ea - cut-scene "Revelarea Scrisorii");  
> * am mai adaugat dialoguri;  
> * Sărbători binecuvântate si un an nou plin de bucurii!🌟🎁🎉  


> Până în săptămâna a 13-a:  
> * am imbunatatit controlul gameplay-ului: movement prin wasd, dar acum directia se poate schimba si din mouse;  
> * animatia inimii sa pulseze;  
> * am facut monstrul ("Crawler-ul") sa ne urmareasca cat timp suntem in subsol;  
> * am adaugat restul de dialoguri dintre personaj si vocea copilului;  
> * am amenajat zona cimitirului astfel incat sa fie mult mai creepy: am adaugat efect de ceata, am facut ca crucea sa straluceasca, am adaugat sicriul unde trebuie ingropata inima, am adaugat copaci si alte elemente de decor specifice unui cimitir;
> * am terminat teleportarea: (este functionala): atunci cand jucatorul trece prin portal, este teleportat catre destinatie;  
> * am adaugat cerul: atmosfera de noapte cu luna care straluceste si se roteste;  


Până în săptămâna a 14-a:  
* am imbunatatit gameplay-ul si coliziunile pentru diferite obiecte;
* gameplay aproape complet, cu mici lucruri ce au ramas de implementat
* am modificat scale, rotation la animatia inimii sa pulseze si am atasat-o obiectului;
* am adaugat animatii la la usile prin care player-ul intra si unde se face teleportarea;  
* am setat animatiile de la deschiderea usilor sa se execute doar atunci cand jucatorul se apropie de acestea;
* am setat ca animatia de deschidere a cufarului sa se execute doar atunci cand jucatorul are cheia corespunzatoare pentru a o deschide;  
* am lucrat la poveste;  


//TODO - almost done (pentru a fi gata jocul):   
* de adaugat scriptul pentru ingroparea inimii si terminare a jocului;  
* supriza de la final (playerul afla de fapt ce s-a intamplat);  
