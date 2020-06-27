# GuessCapital
simple app game in C# and Java


### Testo
Si scriva una app che interroga il sito: http://api.worldbank.org/country?per_page=10&region=EMU
Fra le altre informazioni, il sito della World Bank contiene l'elenco di tutte le nazioni, divise per area geografica.
Queste informazioni possono essere utilizzate per costruire un quiz sulle capitali.
Si seleziona un'area geografica, viene proposta una nazione e bisogna indovinare la capitale.
E' possibile costruire varie versioni:
* il gioco avviene consultando le informazioni on-line
* in fase di primo avvio del gioco le informazioni vengono scaricate e salvate su file; il gioco si basa sulle informazioni salvate localmente.
* vengono salvati su file i record delle prestazioni dei vari giocatori

### Nome Applicazione
Il nome assegnato all’applicazione è GuessCapitals, la seguente immagine è il logo scelto per l’applicazione.

![image logo](/GuessCapital/Resources/icon.png)
 
### Activity
L’app GuessCapitals è strutturata nella seguente maniera:
* Main → Activity principale dell’applicazione dove si può scegliere la
modalità di gioco. Capitali Europee o Capitali del mondo.
* Game → Activity per il gioco, viene restituita una nazione in modo
casuale e l’utente deve scrivere la capitale corrispondente.
 
![screen_0](/screen_0.png)
![screen_1](/screen_1.png)
