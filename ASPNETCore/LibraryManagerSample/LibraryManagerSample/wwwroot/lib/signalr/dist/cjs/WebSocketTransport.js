"use strict";
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
Object.defineProperty(exports, "__esModule", { value: true });
var tslib_1 = require("tslib");
var ILogger_1 = require("./ILogger");
var ITransport_1 = require("./ITransport");
var Utils_1 = require("./Utils");
var WebSocketTransport = /** @class */ (function () {
    function WebSocketTransport(accessTokenFactory, logger, logMessageContent) {
        this.logger = logger;
        this.accessTokenFactory = accessTokenFactory || (function () { return null; });
        this.logMessageContent = logMessageContent;
    }
    WebSocketTransport.prototype.connect = function (url, transferFormat) {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var _this = this;
            var token;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        Utils_1.Arg.isRequired(url, "url");
                        Utils_1.Arg.isRequired(transferFormat, "transferFormat");
                        Utils_1.Arg.isIn(transferFormat, ITransport_1.TransferFormat, "transferFormat");
                        if (typeof (WebSocket) === "undefined") {
                            throw new Error("'WebSocket' is not supported in your environment.");
                        }
                        this.logger.log(ILogger_1.LogLevel.Trace, "(WebSockets transport) Connecting");
                        return [4 /*yield*/, this.accessTokenFactory()];
                    case 1:
                        token = _a.sent();
                        if (token) {
                            url += (url.indexOf("?") < 0 ? "?" : "&") + ("access_token=" + encodeURIComponent(token));
                        }
                        return [2 /*return*/, new Promise(function (resolve, reject) {
                                url = url.replace(/^http/, "ws");
                                var webSocket = new WebSocket(url);
                                if (transferFormat === ITransport_1.TransferFormat.Binary) {
                                    webSocket.binaryType = "arraybuffer";
                                }
                                webSocket.onopen = function (event) {
                                    _this.logger.log(ILogger_1.LogLevel.Information, "WebSocket connected to " + url);
                                    _this.webSocket = webSocket;
                                    resolve();
                                };
                                webSocket.onerror = function (event) {
                                    reject(event.error);
                                };
                                webSocket.onmessage = function (message) {
                                    _this.logger.log(ILogger_1.LogLevel.Trace, "(WebSockets transport) data received. " + Utils_1.getDataDetail(message.data, _this.logMessageContent) + ".");
                                    if (_this.onreceive) {
                                        _this.onreceive(message.data);
                                    }
                                };
                                webSocket.onclose = function (event) {
                                    // webSocket will be null if the transport did not start successfully
                                    _this.logger.log(ILogger_1.LogLevel.Trace, "(WebSockets transport) socket closed.");
                                    if (_this.onclose) {
                                        if (event.wasClean === false || event.code !== 1000) {
                                            _this.onclose(new Error("Websocket closed with status code: " + event.code + " (" + event.reason + ")"));
                                        }
                                        else {
                                            _this.onclose();
                                        }
                                    }
                                };
                            })];
                }
            });
        });
    };
    WebSocketTransport.prototype.send = function (data) {
        if (this.webSocket && this.webSocket.readyState === WebSocket.OPEN) {
            this.logger.log(ILogger_1.LogLevel.Trace, "(WebSockets transport) sending data. " + Utils_1.getDataDetail(data, this.logMessageContent) + ".");
            this.webSocket.send(data);
            return Promise.resolve();
        }
        return Promise.reject("WebSocket is not in the OPEN state");
    };
    WebSocketTransport.prototype.stop = function () {
        if (this.webSocket) {
            this.webSocket.close();
            this.webSocket = null;
        }
        return Promise.resolve();
    };
    return WebSocketTransport;
}());
exports.WebSocketTransport = WebSocketTransport;
//# sourceMappingURL=WebSocketTransport.js.map