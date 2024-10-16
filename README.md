clone this repository. 

then run 'dotnet run'

once you have Nitro (the UI for graphql) running create a new document and run the following graphql 

--------------------------
subscription { 
   onMessageReceived { 
    sender
    content 
    
   }
}

Next, open another Nitro tab (not chrome tab) and enter the followings. When you run this, you will noticed events are being sent into the previous tab. Change the value here in the mutation and you will see what i mean.


mutation { 
   sendMessage(name: "alice", content: "ricky")
   {
      sender
      content
   }
}







