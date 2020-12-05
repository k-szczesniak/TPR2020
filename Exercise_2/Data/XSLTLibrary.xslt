<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:ws="http://www.w3schools.com">
	<xsl:template match="/">
		<html>
			<body>
				<h2>Library</h2>
				<table border="1">
					<tr bgcolor="#9acd32">
						<th>Title</th>
						<th>Author</th>
						<th>Genre</th>
						<th>Price</th>
					</tr>
					<xsl:for-each select="ws:Library/ws:Books/ws:Book">
						<tr>
							<td>
								<xsl:value-of select="ws:Title"/>
							</td>
							<td>
								<xsl:value-of select="ws:Author"/>
							</td>
							<td>
								<xsl:value-of select="ws:Genre"/>
							</td>
							<td>
								<xsl:value-of select="ws:Price"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>