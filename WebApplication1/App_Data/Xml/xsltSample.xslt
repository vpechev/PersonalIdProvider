<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt" 
                xmlns:exsl="http://exslt.org/common" 
                exclude-result-prefixes="msxsl" 
                extension-element-prefixes="exsl"
>
    <xsl:output method="html" indent="yes"/>
  
    <xsl:template match="/">
      <html>
        <head>
          <title>Personal Document</title>
          <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" integrity="sha512-dTfge/zgoMYpP7QbHy4gWMEGsbsdZeCXz7irItjcC3sPUFtf0kuFbDz/ixG7ArTxmDjLXDmezHubeNikyKGVyQ==" crossorigin="anonymous" />
          <style>
            ul { list-style-type: none; }

            ul.labels>li { font-weight: bold; }

            ul.values>li { font-style: oblique; font-size: 14px; }
          </style>
        </head>
        <body>
          <h1 class="jumbotron">Personal Id</h1>
          <div class="col col-lg-3">
            <ul class="labels">
                <li> First Name </li> <hr />
                <li> Last Name </li> <hr />
                <li> Is Male </li> <hr />
                <li> Personal Number </li> <hr />
                <li> Age </li> <hr />
                <li> BirthDate </li> <hr />
                <li> Height </li> <hr />
                <li> Country </li> <hr />
                <li> Town </li> <hr />
                <li> Street Name </li> <hr />
                <li> Street Number </li> <hr />
                <li> Personal Document Number </li> <hr />
                <li> Issue Date </li> <hr />
                <li> Expiration Date </li> <hr />
              </ul>
            </div>
          <div class="col col-lg-6">
            <ul class="values">
                <li><xsl:value-of select="personalDocument/person/firstName"/></li> <hr />
                <li> <xsl:value-of select="personalDocument/person/lastName"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/isMale"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/personalNumber"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/age"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/birthDate"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/height"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/address/country"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/address/town"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/address/streetName"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/person/address/streetNumber"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/document/documentNumber"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/document/dateOfIssue"/> </li> <hr />
                <li> <xsl:value-of select="personalDocument/document/dateOfExpiration"/> </li> <hr />
             </ul>
            </div>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>