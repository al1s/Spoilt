﻿// Check local strorage for userId and create if needed
let UserConnectionId;
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
    let str = '';
    const possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (let i = 0; i < 10; i++) {
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

// Event listener and handler for voting functionality
$('.upvote').on('click', function (e) {
    e.preventDefault();
    const movieID = $(this).data("movieid");
    const spoilerID = $(this).data("spoilerid");

    // Post to Votes table
    addVoteForUser(e, movieID, spoilerID);
});

// Make AJAX call to POST Vote. Change number of votes on DOM only if vote successfully posted.
function addVoteForUser(e, movieID, spoilerID) {
    e.preventDefault();
    const userSessionID = getUserConnectionId();
    $.ajax({
        url: '/Votes/Create',
        method: 'POST',
        data: {
            MovieID: movieID,
            SpoilerID: spoilerID,
            UserSessionID: userSessionID
        }
    })
        .then((resp, status, xhr) => {
            voteStatus = JSON.parse(xhr.responseText);
            if (voteStatus.voteCounted) {
                let votes = parseInt($(`.display-votes-spoiler-${spoilerID}`).text());

                ++votes;
                $(`.display-votes-spoiler-${spoilerID}`).text(votes);
            }
        });
}