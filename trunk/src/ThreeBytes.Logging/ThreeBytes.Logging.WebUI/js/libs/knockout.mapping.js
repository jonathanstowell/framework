// Knockout Mapping plugin v2.0.1
// (c) 2011 Steven Sanderson, Roy Jacobs - http://knockoutjs.com/
// License: Ms-Pl (http://www.opensource.org/licenses/ms-pl.html)

ko.exportSymbol = function (g, q) { for (var k = g.split("."), i = window, e = 0; e < k.length - 1; e++) i = i[k[e]]; i[k[k.length - 1]] = q }; ko.exportProperty = function (g, q, k) { g[q] = k };
(function () {
    function g(a, c) { for (var b in c) c.hasOwnProperty(b) && c[b] && (a[b] && !(a[b] instanceof Array) ? g(a[b], c[b]) : a[b] = c[b]) } function q(a, c) { var b = {}; g(b, a); g(b, c); return b } function k(a) { return a && typeof a === "object" && a.constructor == (new Date).constructor ? "date" : typeof a } function i(a, c) {
        a = a || {}; if (a.create instanceof Function || a.update instanceof Function || a.key instanceof Function || a.arrayChanged instanceof Function) a = { "": a }; if (c) a.ignore = e(c.ignore, a.ignore), a.include = e(c.include, a.include), a.copy =
e(c.copy, a.copy); a.ignore = e(a.ignore, j.ignore); a.include = e(a.include, j.include); a.copy = e(a.copy, j.copy); a.mappedProperties = a.mappedProperties || {}; return a
    } function e(a, c) { a instanceof Array || (a = k(a) === "undefined" ? [] : [a]); c instanceof Array || (c = k(c) === "undefined" ? [] : [c]); return a.concat(c) } function J(a, c) {
        var b = ko.dependentObservable; ko.dependentObservable = function (b, c, d) {
            var d = d || {}, k = d.deferEvaluation; b && typeof b == "object" && (d = b); var t = !1, e = function (b) {
                var c = n({ read: function () {
                    t || (ko.utils.arrayRemoveItem(a,
b), t = !0); return b.apply(b, arguments)
                }, write: function (a) { return b(a) }, deferEvaluation: !0
                }); c.__ko_proto__ = n; return c
            }; d.deferEvaluation = !0; b = new n(b, c, d); b.__ko_proto__ = n; k || (a.push(b), b = e(b)); return b
        }; var d = c(); ko.dependentObservable = b; return d
    } function z(a, c, b, d, f, e) {
        var y = ko.utils.unwrapObservable(c) instanceof Array, e = e || ""; if (ko.mapping.isMapped(a)) var r = ko.utils.unwrapObservable(a)[m], b = q(r, b); var t = function () { return b[d] && b[d].create instanceof Function }, j = function (a) {
            return J(C, function () {
                return b[d].create({ data: a ||
c, parent: f
                })
            })
        }, g = function () { return b[d] && b[d].update instanceof Function }, o = function (a, K) { var e = { data: K || c, parent: f, target: ko.utils.unwrapObservable(a) }; if (ko.isWriteableObservable(a)) e.observable = a; return b[d].update(e) }; if (A.get(c)) return a; d = d || ""; if (y) {
            var y = [], r = !1, h = function (a) { return a }; if (b[d] && b[d].key) h = b[d].key, r = !0; if (!ko.isObservable(a)) a = ko.observableArray([]), a.mappedRemove = function (b) { var c = typeof b == "function" ? b : function (a) { return a === h(b) }; return a.remove(function (a) { return c(h(a)) }) },
a.mappedRemoveAll = function (b) { var c = w(b, h); return a.remove(function (a) { return ko.utils.arrayIndexOf(c, h(a)) != -1 }) }, a.mappedDestroy = function (b) { var c = typeof b == "function" ? b : function (a) { return a === h(b) }; return a.destroy(function (a) { return c(h(a)) }) }, a.mappedDestroyAll = function (b) { var c = w(b, h); return a.destroy(function (a) { return ko.utils.arrayIndexOf(c, h(a)) != -1 }) }, a.mappedIndexOf = function (b) { var c = w(a(), h), b = h(b); return ko.utils.arrayIndexOf(c, b) }, a.mappedCreate = function (b) {
    if (a.mappedIndexOf(b) !==
-1) throw Error("There already is an object with the key that you specified."); var c = t() ? j(b) : b; g() && (b = o(c, b), ko.isWriteableObservable(c) ? c(b) : c = b); a.push(c); return c
}; var l = w(ko.utils.unwrapObservable(a), h).sort(), i = w(c, h); r && i.sort(); for (var r = ko.utils.compareArrays(l, i), l = {}, i = [], n = 0, v = r.length; n < v; n++) {
                var u = r[n], s, p = e + "[" + n + "]"; switch (u.status) {
                    case "added": var x = B(ko.utils.unwrapObservable(c), u.value, h); s = ko.utils.unwrapObservable(z(void 0, x, b, d, a, p)); p = F(ko.utils.unwrapObservable(c), x, l); i[p] =
s; l[p] = !0; break; case "retained": x = B(ko.utils.unwrapObservable(c), u.value, h); s = B(a, u.value, h); z(s, x, b, d, a, p); p = F(ko.utils.unwrapObservable(c), x, l); i[p] = s; l[p] = !0; break; case "deleted": s = B(a, u.value, h)
                } y.push({ event: u.status, item: s })
            } a(i); b[d] && b[d].arrayChanged && ko.utils.arrayForEach(y, function (a) { b[d].arrayChanged(a.event, a.item) })
        } else if (D(c)) {
            a = ko.utils.unwrapObservable(a); if (!a) if (t()) return l = j(), g() && (l = o(l)), l; else { if (g()) return o(l); a = {} } g() && (a = o(a)); A.save(c, a); G(c, function (d) {
                var f = e.length ?
e + "." + d : d; if (ko.utils.arrayIndexOf(b.ignore, f) == -1) if (ko.utils.arrayIndexOf(b.copy, f) != -1) a[d] = c[d]; else { var h = A.get(c[d]) || z(a[d], c[d], b, d, a, f); if (ko.isWriteableObservable(a[d])) a[d](ko.utils.unwrapObservable(h)); else a[d] = h; b.mappedProperties[f] = !0 } 
            })
        } else switch (k(c)) { case "function": g() ? ko.isWriteableObservable(c) ? (c(o(c)), a = c) : a = o(c) : a = c; break; default: ko.isWriteableObservable(a) ? g() ? a(o(a)) : a(ko.utils.unwrapObservable(c)) : (a = t() ? j() : ko.observable(ko.utils.unwrapObservable(c)), g() && a(o(a))) } return a
    }
    function F(a, c, b) { for (var d = 0, f = a.length; d < f; d++) if (b[d] !== !0 && a[d] === c) return d; return null } function H(a, c) { var b; c && (b = c(a)); k(b) === "undefined" && (b = a); return ko.utils.unwrapObservable(b) } function B(a, c, b) { a = ko.utils.arrayFilter(ko.utils.unwrapObservable(a), function (a) { return H(a, b) === c }); if (a.length == 0) throw Error("When calling ko.update*, the key '" + c + "' was not found!"); if (a.length > 1 && D(a[0])) throw Error("When calling ko.update*, the key '" + c + "' was not unique!"); return a[0] } function w(a, c) {
        return ko.utils.arrayMap(ko.utils.unwrapObservable(a),
function (a) { return c ? H(a, c) : a })
    } function G(a, c) { if (a instanceof Array) for (var b = 0; b < a.length; b++) c(b); else for (b in a) c(b) } function D(a) { var c = k(a); return c === "object" && a !== null && c !== "undefined" } function I() { var a = [], c = []; this.save = function (b, d) { var f = ko.utils.arrayIndexOf(a, b); f >= 0 ? c[f] = d : (a.push(b), c.push(d)) }; this.get = function (b) { b = ko.utils.arrayIndexOf(a, b); return b >= 0 ? c[b] : void 0 } } ko.mapping = {}; var m = "__ko_mapping__", n = ko.dependentObservable, E = 0, C, A, v = { include: ["_destroy"], ignore: [], copy: [] },
j = v; ko.mapping.isMapped = function (a) { return (a = ko.utils.unwrapObservable(a)) && a[m] }; ko.mapping.fromJS = function (a) {
    if (arguments.length == 0) throw Error("When calling ko.fromJS, pass the object you want to convert."); window.setTimeout(function () { E = 0 }, 0); E++ || (C = [], A = new I); var c, b; arguments.length == 2 && (arguments[1][m] ? b = arguments[1] : c = arguments[1]); arguments.length == 3 && (c = arguments[1], b = arguments[2]); b && (c = q(c, b[m])); c = i(c); var d = z(b, a, c); b && (d = b); --E || window.setTimeout(function () {
        ko.utils.arrayForEach(C,
function (a) { a && a() })
    }, 0); d[m] = q(d[m], c); return d
}; ko.mapping.fromJSON = function (a) { var c = ko.utils.parseJson(a); arguments[0] = c; return ko.mapping.fromJS.apply(this, arguments) }; ko.mapping.updateFromJS = function () { throw Error("ko.mapping.updateFromJS, use ko.mapping.fromJS instead. Please note that the order of parameters is different!"); }; ko.mapping.updateFromJSON = function () {
    throw Error("ko.mapping.updateFromJSON, use ko.mapping.fromJSON instead. Please note that the order of parameters is different!");
}; ko.mapping.toJS = function (a, c) {
    j || ko.mapping.resetDefaultOptions(); if (arguments.length == 0) throw Error("When calling ko.mapping.toJS, pass the object you want to convert."); if (!(j.ignore instanceof Array)) throw Error("ko.mapping.defaultOptions().ignore should be an array."); if (!(j.include instanceof Array)) throw Error("ko.mapping.defaultOptions().include should be an array."); if (!(j.copy instanceof Array)) throw Error("ko.mapping.defaultOptions().copy should be an array."); c = i(c, a[m]); return ko.mapping.visitModel(a,
function (a) { return ko.utils.unwrapObservable(a) }, c)
}; ko.mapping.toJSON = function (a, c) { var b = ko.mapping.toJS(a, c); return ko.utils.stringifyJson(b) }; ko.mapping.defaultOptions = function () { if (arguments.length > 0) j = arguments[0]; else return j }; ko.mapping.resetDefaultOptions = function () { j = { include: v.include.slice(0), ignore: v.ignore.slice(0), copy: v.copy.slice(0)} }; ko.mapping.visitModel = function (a, c, b) {
    b = b || {}; b.visitedObjects = b.visitedObjects || new I; b.parentName || (b = i(b)); var d, f = ko.utils.unwrapObservable(a);
    if (D(f)) c(a, b.parentName), d = f instanceof Array ? [] : {}; else return c(a, b.parentName); b.visitedObjects.save(a, d); var e = b.parentName; G(f, function (a) {
        if (!(b.ignore && ko.utils.arrayIndexOf(b.ignore, a) != -1)) {
            var g = f[a], i = b, j = e || ""; f instanceof Array ? e && (j += "[" + a + "]") : (e && (j += "."), j += a); i.parentName = j; if (!(ko.utils.arrayIndexOf(b.copy, a) === -1 && ko.utils.arrayIndexOf(b.include, a) === -1 && f[m] && f[m].mappedProperties && !f[m].mappedProperties[a] && !(f instanceof Array))) switch (k(ko.utils.unwrapObservable(g))) {
                case "object": case "undefined": i =
b.visitedObjects.get(g); d[a] = k(i) !== "undefined" ? i : ko.mapping.visitModel(g, c, b); break; default: d[a] = c(g, b.parentName)
            } 
        } 
    }); return d
}; ko.exportSymbol("ko.mapping", ko.mapping); ko.exportSymbol("ko.mapping.fromJS", ko.mapping.fromJS); ko.exportSymbol("ko.mapping.fromJSON", ko.mapping.fromJSON); ko.exportSymbol("ko.mapping.isMapped", ko.mapping.isMapped); ko.exportSymbol("ko.mapping.defaultOptions", ko.mapping.defaultOptions); ko.exportSymbol("ko.mapping.toJS", ko.mapping.toJS); ko.exportSymbol("ko.mapping.toJSON",
ko.mapping.toJSON); ko.exportSymbol("ko.mapping.updateFromJS", ko.mapping.updateFromJS); ko.exportSymbol("ko.mapping.updateFromJSON", ko.mapping.updateFromJSON); ko.exportSymbol("ko.mapping.visitModel", ko.mapping.visitModel)
})();