// Add Save/Update buttons click handlers
// Add UserSession id handling
// $('#spoilerUpVoteButton').on('click', addVoteForUser);
//$('#spoilerDownVoteButton').on('click', deleteVoteForUser);
MovieId = $('#movieId').text();
SpoilerId = $('#SpoilerId');

// Check local strorage for userId and create if needed
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

// function to create a new user id
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
    $('#UserSessionID').val(getUserConnectionId());
});

// TODO: Even though a double vote won't get saved to the Votes table, the front end will still increment the count. How can we prevent this?

// Vote limiting variable
let userGetsOneVote = 0;

// Event listener and handler for voting functionality
$('.upvote').on('click', function (e) {
    e.preventDefault();
    const movieID = $(this).data("movieid");
    const spoilerID = $(this).data("spoilerid");

    // Post to Votes table
    addVoteForUser(e, movieID, spoilerID);
});

// Make AJAX call to POST Vote
function addVoteForUser(e, movieID, spoilerID) {
    e.preventDefault();
    const userSessionID = getUserConnectionId();
    $.ajax({
        url: '/Votes/Create',
        method: 'POST',
        data: {
            MovieID: movieID,
            SpoilerID: spoilerID,
            SessionID: userSessionID
        }
    })
        .done((resp, status, xhr) => {
            voteStatus = JSON.parse(xhr.responseText);
            if (voteStatus.voted) {
                let votes = parseInt($(`.display-votes-spoiler-${spoilerID}`).text());

                if (userGetsOneVote < 1) {
                    ++votes;
                    ++userGetsOneVote;
                }

                $(`.display-votes-spoiler-${spoilerID}`).text(votes);
            }
        });
}