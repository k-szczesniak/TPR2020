<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="Library">
		<html>
			<body>
				<h2>Library</h2>
				<table border="1">
					<tr bgcolor="#9acd32">
						<th>ID</th>
						<th>Title</th>
						<th>Author</th>
						<th>Genre</th>
						<th>Price</th>
					</tr>
					<xsl:for-each select="Books/Book">
						<tr>
							<td>
								<xsl:value-of select="@Id"/>
							</td>
							<td>
								<xsl:value-of select="Title"/>
							</td>
							<td>
								<xsl:value-of select="Author"/>
							</td>
							<td>
								<xsl:value-of select="Genre"/>
							</td>
							<td>
								<xsl:value-of select="Price"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>