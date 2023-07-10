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
    if(player === null)
    {
      console.log('PLAYER IS NOT INITED!');
      return;
    }

    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);

    console.log('PLAYER DATA IS SAVED');
  },

  LoadExtern: function () {
    if(player === null){
      console.log('PLAYER IS NOT INITED!');
      myGameInstance.SendMessage('AuthButtonController', 'OnAuthNotSuccessed');
      return;
    }

    player.getData().then(_date => {
      const myJson = JSON.stringify(_date);
      myGameInstance.SendMessage('User Manager', 'SetPlayerInfo', myJson);
    });

    console.log('PLAYER DATA IS LOADED!')
  },

});