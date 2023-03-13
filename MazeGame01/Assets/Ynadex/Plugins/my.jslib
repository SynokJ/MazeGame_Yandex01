mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  OnAuth: function()
  {
    auth();
  },

  OnGameRated: function()
  {
    ysdk.feedback.canReview()
    .then(({ value, reason }) => {
      if (value) {
        ysdk.feedback.requestReview()
        .then(({ feedbackSent }) => {
          console.log(feedbackSent);
          myGameInstance.SendMessage('RateButtonController', 'GameIsRated');
        })
      } else {
        console.log(reason)
      }
    })
  },

  SaveExtern: function (date) {
    if(player == null)
    {
      console.log('player is not inited!');
      return;
    }

    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);
  },

  LoadExtern: function () {
    if(player == null){
      console.log('player is not inited!');
      return;
    }

    player.getData().then(_date => {
      const myJson = JSON.stringify(_date);
      myGameInstance.SendMessage('User Manager', 'SetPlayerInfo', myJson);
      console.log('player info is inited');
    });

    console.log('LoadExternFinished!')
  },

});