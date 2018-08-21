"use strict";
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
Object.defineProperty(exports, "__esModule", { value: true });
// Version token that will be replaced by the prepack command
/** The version of the SignalR client. */
exports.VERSION = "1.0.2";
var Errors_1 = require("./Errors");
exports.HttpError = Errors_1.HttpError;
exports.TimeoutError = Errors_1.TimeoutError;
var HttpClient_1 = require("./HttpClient");
exports.DefaultHttpClient = HttpClient_1.DefaultHttpClient;
exports.HttpClient = HttpClient_1.HttpClient;
exports.HttpResponse = HttpClient_1.HttpResponse;
var HubConnection_1 = require("./HubConnection");
exports.HubConnection = HubConnection_1.HubConnection;
var HubConnectionBuilder_1 = require("./HubConnectionBuilder");
exports.HubConnectionBuilder = HubConnectionBuilder_1.HubConnectionBuilder;
var IHubProtocol_1 = require("./IHubProtocol");
exports.MessageType = IHubProtocol_1.MessageType;
var ILogger_1 = require("./ILogger");
exports.LogLevel = ILogger_1.LogLevel;
var ITransport_1 = require("./ITransport");
exports.HttpTransportType = ITransport_1.HttpTransportType;
exports.TransferFormat = ITransport_1.TransferFormat;
var Loggers_1 = require("./Loggers");
exports.NullLogger = Loggers_1.NullLogger;
var JsonHubProtocol_1 = require("./JsonHubProtocol");
exports.JsonHubProtocol = JsonHubProtocol_1.JsonHubProtocol;
//# sourceMappingURL=index.js.map