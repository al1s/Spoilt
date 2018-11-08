// Add Save/Update buttons click handlers
// Add UserSession id handling
// $('#spoilerUpVoteButton').on('click', addVoteForUser);
'use strict';

$('#spoilerDownVoteButton').on('click', deleteVoteForUser);
MovieId = $('#movieId').text();
SpoilerId = $('#SpoilerId');

function deleteVoteForUser(e) {
    e.preventDefault();
    $.ajax({
        url: '/Votes/DeleteConfirmed',
        method: 'POST',
        data: {
            MovieId: MovieId,
            SpoilerId: SpoilerId,
            SessionId: getUserConnectionId()
        }
    }).then(function (resp, status, xhr) {
        if (status === "500") {
            errMsg = xhr.responseJSON();
        }
    });
}

// Check local strorage for userId and create if needed
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

// function to create a new user id
function createUserConnectionId() {
    var str = '';
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (var i = 0; i < 10; i++) {
        str += possible.charAt(Math.floor(Math.random() * possible.length));
    }
    return str;
};

// Make AJAX call to POST Vote
function addVoteForUser(e, movieID, spoilerID) {
    e.preventDefault();
    var userSessionID = getUserConnectionId();
    $.ajax({
        url: '/Votes/Create',
        method: 'POST',
        data: {
            MovieID: movieID,
            SpoilerID: spoilerID,
            UserSessionID: userSessionID
        }
    }).then(function (resp, status, xhr) {
        if (status === "500") {
            errMsg = xhr.responseJSON();
        }
    });
}

$(document).ready(function () {
    $('.sidenav').sidenav();
    $('#UserSessionID').val(getUserConnectionId());
});

$('.upvote').on('click', function (e) {
    e.preventDefault();
    var movieID = $(this).data("movieid");
    var spoilerID = $(this).data("spoilerid");
    addVoteForUser(e, movieID, spoilerID);
});

