const t = require('xmllint');

process.on('message', ({ xml, xsd }) => {
  process.send(t.validateXML({ xml: xml, schema: xsd }));
});