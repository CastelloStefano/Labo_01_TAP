using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExecuteMe : Attribute
    {
        public Object[] param { get; }
        public ExecuteMe(params object[] prm)
        {
            this.param = prm;
        }
    }
}


/*
 * Seconda release
Perfezionare il progetto precedente sotto i seguenti aspetti.

Corretto riferimento a MyLibrary
Eliminare il riferimento al progetto MyLibrary nel progetto Executer, che logicamente non dovrebbe esserci ed è stato introdotto solo per semplificare il caricamento della dll, e modificare il codice in modo che continui a funzionare come prima.

Provate a modificare MyLibrary aggiungendo un metodo annotato con [ExecuteMe] e fare F5 (dell'Executer), sia prima che dopo aver eliminato il riferimento (e fatto le conseguenti modifiche al codice).
Confrontate i risultati ottenuti nei due casi. Ci sono differenze? quali e perché?

Parametri di ExecuteMe
Provate a sperimentare con quali valori e quali tipi sono ammissibili come argomenti per l'annotazione. 
Riflettete sul perché delle restrizioni.

Gestione errori: assenza del costruttore di default
Gestire il caso in cui in MyLibrary siano presenti classi senza il costruttore di default in modo che il fallimento sia "graceful" e l'esecuzione prosegua con l'analisi delle classi successive.

Per verificare di aver correttamente gestito questo caso, aggiungete alla vostra MyLibrary una classe pubblica senza costruttore di default e con almeno un metodo pubblico annotato con [ExecuteMe], seguita da una ulteriore classe pubblica con costruttore di default e almeno un metodo pubblico annotato con [ExecuteMe]

Gestione errori: parametri sbagliati
Gestire il caso in cui un'annotazione con [ExecuteMe] fornisca argomenti di invocazione non adeguati come numero o come tipo, fornendo un messaggio di errore informativo e proseguendo con l'analisi dei metodi e delle classi successive.

Per verificare di aver correttamente gestito questo caso, aggiungete ad una classe pubblica, con costruttore di default, un metodo pubblico con un argomento di tipo int annotato con [ExecuteMe("tre")], seguito da un ulteriore metodo pubblico M1024 senza argomenti annotato con [ExecuteMe] e verificate che la chiamata di M1024 sia correttamente eseguita.

Provate a gestire anche il caso in cui il metodo si aspetti parametri per riferimento.

Per chi ancora avesse tempo e si annoiasse
Come si potrebbe gestire il caso di costruttori non di default? 
Valutate due possibili soluzioni:

Introdurre un (ulteriore) custom attribute per annotare i costruttori con valori dei parametri, da usare in assenza del costruttore di default.
Sotto quali aspetti questo è diverso da avere parametri con valore di default nel costruttore?
Chiedere all'utente di fornire i valori dei parametri per il costruttore.
Riflettete su come si può gestire il caso di parametri opzionali e "params". Considerate le interazioni fra i due casi e i vari "corner case" dovuti alla presenza di più parametri opzionali nella dichiarazione, di cui solo alcuni esplicitamente presenti nell'annotazione.
Come punto di partenza considerate che il compilatore ammette:

"params" solo come ultimo parametro;
parametri opzionali solo come ultimi (ad eccezione, se presente, di un eventuale "params")
omissione di un argomento corrispondente ad un parametro opzionale "intermedio" solo se i successivi argomenti sono indicati nominalmente, cioè se abbiamo dichiarato
public void Abc(int a, int b = 1, string c = 2, int d = 3,double e=5.5)
la chiamata
Abc(0,c:"puffo", e:2.3);
è corretta, mentre la seguente non lo è
Abc(0,"puffo", 2.3);
nonostante il fatto che i tipi permetterebbero di capire la corrispondenza fra argomenti e parametri.
*/
