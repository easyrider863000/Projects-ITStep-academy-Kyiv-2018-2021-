(function () {
    var setting = {"height":400,"width":400,"zoom":14,"queryString":"Graniczna 24a, Warszawa, Польша","place_id":"EiVHcmFuaWN6bmEgMjRhLCBXYXJzemF3YSwg0J_QvtC70YzRiNCwIjASLgoUChIJFURXVZLTHkcR3MzNdrc5omEQGCoUChIJS_F3VZLTHkcRrRMbajd14wg","satellite":false,"centerCoord":[52.237375843788314,21.00307149259035],"cid":"0x338ba33858c243b6","lang":"ru","cityUrl":"/poland/warsaw","cityAnchorText":"Карта [CITY1], Carpathians - Poland, Польша","id":"map-9cd199b9cc5410cd3b1ad21cab2e54d3","embed_id":"242229"};
    var d = document;
    var s = d.createElement('script');
    s.src = 'https://1map.com/js/script-for-user.js?embed_id=242229';
    s.async = true;
    s.onload = function (e) {
      window.OneMap.initMap(setting)
    };
    var to = d.getElementsByTagName('script')[0];
    to.parentNode.insertBefore(s, to);
  })();