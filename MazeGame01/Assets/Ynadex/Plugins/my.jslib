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

  LoadExtern: function () {
    // todo
  },

  SaveExtern: function (string date) {
    // todo
  },

});