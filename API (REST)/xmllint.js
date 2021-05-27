const t = require('xmllint');
// validate XML
process.on('message', ({ xml, xsd }) => {
  process.send(t.validateXML({ xml: xml, schema: xsd }));
});