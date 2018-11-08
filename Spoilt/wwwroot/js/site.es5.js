// Check local strorage for userId and create if needed
'use strict';

var UserConnectionId = undefined;
function getUserConnectionId() {
    if (!localStorage.getItem('UserConnectionId')) {
        UserConnectionId = !!UserConnectionId ? UserConnectionId : createUserConnectionId();
        localStorage.setItem('UserConnectionId', UserConnectionId);
    } else {
        UserConnectionId = !!UserConnectionId ? UserConnectionId : localStorage.getItem('UserConnectionId');
    }

    return UserConnectionId;
};

// Function to create a new user id
function createUserConnectionId() {
    var str = '';
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (var i = 0; i < 10; i++) {
        str += possible.charAt(Math.floor(Math.random() * possible.length));
    }
    return str;
};

$(document).ready(function () {
    $('.sidenav').sidenav();
    var b = $("nav .categories-container");
    if (b.length) {
        b.pushpin({ top: b.offset().top });
    }

    $('#UserSessionID').val(getUserConnectionId());

    $('.tabs').tabs();
});

// Vote limiting variable
var userGetsOneVote = 0;

// Event listener and handler for voting functionality
$('.upvote').on('click', function (e) {
    e.preventDefault();
    var movieID = $(this).data("movieid");
    var spoilerID = $(this).data("spoilerid");

    // Post to Votes table
    addVoteForUser(e, movieID, spoilerID);
});

// Make AJAX call to POST Vote. Change number of votes on DOM only if vote successfully posted.
function addVoteForUser(e, movieID, spoilerID) {
    e.preventDefault();
    var userSessionID = getUserConnectionId();
    $.ajax({
        url: '/Votes/Create',
        method: 'POST',
        data: {
            MovieID: movieID,
            SpoilerID: spoilerID,
            SessionID: userSessionID
        }
    }).done(function (resp, status, xhr) {
        voteStatus = JSON.parse(xhr.responseText);
        if (voteStatus.voted) {
            var votes = parseInt($('.display-votes-spoiler-' + spoilerID).text());

            if (userGetsOneVote < 1) {
                ++votes;
                ++userGetsOneVote;
            }

            $('.display-votes-spoiler-' + spoilerID).text(votes);
        }
    });
}

