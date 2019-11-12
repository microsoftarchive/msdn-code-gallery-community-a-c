﻿var providers = {
    google: {
        name: "Google",
        type: 1
    },
    yahoo: {
        name: "Yahoo",
        type: 2
    },
    facebook: {
        name: "Facebook",
        type: 3
    },
    twitter: {
        name: "Twitter",
        type: 4
    },
    linkedin: {
        name: "Linkedin",
        type: 5
    },
    windowslive: {
        name: "WindowsLive",
        type: 6
    }
};

var auth = {
    signin: function (providerName) {
        var provider = providers[providerName];

        if (!provider) {
            return;
        }

        $("#authType").val(provider.type);

        $("#authForm").submit();
    }
};