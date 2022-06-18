var Deco_Mistape={getSelectionData:function(){var parentEl,sel,selChars,selWord,textToHighlight,maxContextLength=140;var stringifyContent=function(string){return typeof string=='string'?string.replace(/\s*(?:(?:\r\n)+|\r+|\n+)\t*/gm,'\r\n').replace(/\s{2,}/gm,' '):'';};var isSubstrUnique=function(substr,context){var split=context.split(substr);var count=split.length-1;return count===1;};var getExactSelPos=function(selection,context){if(isSubstrUnique(selWithContext,context)){return context.indexOf(selWithContext);}
if(!backwards){if(context.substring(sel.anchorOffset,sel.anchorOffset+selection.length)==selection){return sel.anchorOffset;}
var parentElOffset=sel.anchorOffset;var prevEl=sel.anchorNode.previousSibling;while(prevEl!==null){parentElOffset+=prevEl.textContent.length;prevEl=prevEl.previousSibling;}
if(context.substring(parentElOffset,parentElOffset+selection.length)==selection){return parentElOffset;}}
if(backwards&&context.substring(sel.focusOffset,sel.focusOffset+selection.length)==selection){return sel.anchorOffset;}
return-1;};var getExtendedSelection=function(limit,nodeExtensions){limit=parseInt(limit)||40;nodeExtensions=nodeExtensions||{left:'',right:''};var i=0,selContent,selEndNode=sel.focusNode,selEndOffset=sel.focusOffset;while(i<=limit){if((selContent=stringifyContent(sel.toString().trim())).length>=maxContextLength||isSubstrUnique(selContent,context)){return selContent;}
if(i%2==0&&sel.anchorOffset>0||nodeExtensions.left.length&&i<limit/2){if(backwards){sel.collapseToEnd();}
else{sel.collapseToStart();}
sel.modify("move",direction[1],"character");sel.extend(selEndNode,selEndOffset);}
else if(sel.focusOffset<sel.focusNode.length||nodeExtensions.right.length&&i<limit/2){sel.modify('extend',direction[0],'character');if(sel.focusOffset===1){selEndNode=sel.focusNode;selEndOffset=sel.focusOffset;}}
else if(i%2==0){break;}
i++;}
return stringifyContent(sel.toString().trim());};var getExtendedContext=function(context,element,method){var contentPrepend='',contentAppend='',e=element,i;method=method||'textContent';for(i=0;i<20;i++){if(contentPrepend||(e=e.previousSibling)===null){break;}
if((contentPrepend=stringifyContent(e[method].trim())).length){context=contentPrepend+context;}}
e=element;for(i=0;i<20;i++){if(contentAppend||(e=e.nextSibling)===null){break;}
if((contentAppend=stringifyContent(e[method]).trim()).length){context+=contentAppend;}
else if(context.slice(-1)!=' '){context+=' ';}}
return{contents:context,extensions:{left:contentPrepend,right:contentAppend}};};var restoreInitSelection=function(sel,initialSel){sel.collapse(initialSel.anchorNode,initialSel.anchorOffset);sel.extend(initialSel.focusNode,initialSel.focusOffset);};if(window.getSelection&&(sel=window.getSelection()).modify){if(!sel.isCollapsed){selChars=sel.toString();if(!selChars||selChars.length>maxContextLength){return;}
if(sel.rangeCount){parentEl=sel.getRangeAt(0).commonAncestorContainer.parentNode;while(parentEl.textContent==sel.toString()){parentEl=parentEl.parentNode;}}
var range=document.createRange();range.setStart(sel.anchorNode,sel.anchorOffset);range.setEnd(sel.focusNode,sel.focusOffset);var backwards=range.collapsed;range=null;var initialSel={focusNode:sel.focusNode,focusOffset:sel.focusOffset,anchorNode:sel.anchorNode,anchorOffset:sel.anchorOffset};var endNode=sel.focusNode,endOffset=sel.focusOffset;var direction=[],secondChar,oneBeforeLastChar;if(backwards){direction=['backward','forward'];secondChar=selChars.charAt(selChars.length-1);oneBeforeLastChar=selChars.charAt(0);}else{direction=['forward','backward'];secondChar=selChars.charAt(0);oneBeforeLastChar=selChars.charAt(selChars.length-1);}
sel.collapse(sel.anchorNode,sel.anchorOffset);sel.modify("move",direction[0],"character");if(null===secondChar.match(/'[\w\d]'/)){sel.modify("move",direction[0],"character");}
sel.modify("move",direction[1],"word");sel.extend(endNode,endOffset);sel.modify("extend",direction[1],"character");if(null===oneBeforeLastChar.match(/'[\w\d]'/)){sel.modify("extend",direction[1],"character");}
sel.modify("extend",direction[0],"word");if(!backwards&&sel.focusOffset===1){sel.modify("extend",'backward',"character");}
var i=0,lengthBefore,lengthAfter;while(i<5&&(sel.toString().slice(-1).match(/[\s\n\t]/)||'').length){lengthBefore=sel.toString().length;if(backwards){endNode=sel.anchorOffset==0?sel.anchorNode.previousSibling:sel.anchorNode;endOffset=sel.anchorOffset==0?sel.anchorNode.previousSibling.length:sel.anchorOffset;sel.modify('move','backward','character');sel.extend(endNode,endOffset);backwards=false;direction=['forward','backward'];}else{sel.modify('extend','backward','character');}
lengthAfter=sel.toString().length;if(lengthBefore-lengthAfter>1){sel.modify('extend','forward','character');break;}}
selWord=stringifyContent(sel.toString().trim());}}else if((sel=document.selection)&&sel.type!="Control"){var textRange=sel.createRange();if(!textRange||textRange.text.length>maxContextLength){return;}
if(textRange.text){selChars=textRange.text;textRange.expand("word");while(/\s$/.test(textRange.text)){textRange.moveEnd("character",-1);}
selWord=textRange.text;parentEl=textRange.parentNode;}}
if(typeof parentEl=='undefined'){return;}
var selToFindInContext,contextsToCheck={textContent:parentEl.textContent,innerText:parentEl.innerText};textToHighlight=selWord;for(var method in contextsToCheck){if(contextsToCheck.hasOwnProperty(method)&&typeof contextsToCheck[method]!='undefined'){var scope={selection:'word',context:'initial'};var context=stringifyContent(contextsToCheck[method].trim());var selWithContext=stringifyContent(sel.toString().trim());var selPos;var selExactMatch=false;if((selPos=getExactSelPos(selWithContext,context))!=-1){selExactMatch=true;selToFindInContext=selWithContext;break;}
selWithContext=getExtendedSelection(40);scope.selection='word extended';if((selPos=getExactSelPos(selWithContext,context))!=-1){selExactMatch=true;selToFindInContext=selWithContext;break;}
var initialContext=context;var extContext=getExtendedContext(context,parentEl,method);context=extContext.contents;selWithContext=getExtendedSelection(40,extContext.extensions);scope.context='extended';if((selPos=getExactSelPos(selWithContext,context))!=-1){selExactMatch=true;selToFindInContext=selWithContext;break;}
if(!selWithContext){continue;}
if(isSubstrUnique(selWord,selWithContext)||selWord==selChars.trim()){context=selWithContext;selWithContext=selWord;textToHighlight=selWord;scope.selection='word';scope.context='extended';}
else{context=selWord;selWithContext=selChars.trim();textToHighlight=selChars.trim();scope.selection='initial';scope.context='word';}
selPos=context.indexOf(selWithContext);if(selPos!==-1){selToFindInContext=selWithContext;}
else if((selPos=context.indexOf(selWord))!==-1){selToFindInContext=selWord;}
else if((selPos=context.indexOf(selChars))!==-1){selToFindInContext=selChars;}
else{continue;}
break;}}
if(selToFindInContext){sel.removeAllRanges();}
else{restoreInitSelection(sel,initialSel);return;}
if(scope.context=='extended'){context=extContext.extensions.left+initialContext+' '+extContext.extensions.right;}
var contExcerptStartPos,contExcerptEndPos,selPosInContext,highlightedChars,previewText;maxContextLength=Math.min(context.length,maxContextLength);var truncatedContext=context;if(context.length>maxContextLength){if(selPos+selToFindInContext.length/2<maxContextLength/2){selPosInContext='beginning';contExcerptStartPos=0;contExcerptEndPos=Math.max(selPos+selToFindInContext.length,context.indexOf(' ',maxContextLength-10));}
else if(selPos+selToFindInContext.length/2>context.length-maxContextLength/2){selPosInContext='end';contExcerptStartPos=Math.min(selPos,context.indexOf(' ',context.length-maxContextLength+10));contExcerptEndPos=context.length;}
else{selPosInContext='middle';var centerPos=selPos+Math.round(selToFindInContext.length/2);contExcerptStartPos=Math.min(selPos,context.indexOf(' ',centerPos-maxContextLength/2-10));contExcerptEndPos=Math.max(selPos+selToFindInContext.length,context.indexOf(' ',centerPos+maxContextLength/2-10));}
truncatedContext=context.substring(contExcerptStartPos,contExcerptEndPos).trim();if(selPosInContext!='beginning'&&context.charAt(contExcerptStartPos-1)!='.'){truncatedContext='... '+truncatedContext;}
if(selPosInContext!='end'&&context.charAt(contExcerptStartPos+contExcerptEndPos-1)!='.'){truncatedContext=truncatedContext+' ...';}}
if(isSubstrUnique(selChars,textToHighlight)){highlightedChars=textToHighlight.replace(selChars,'<span class="mistape_mistake_inner">'+selChars+'</span>')}
else{highlightedChars='<strong class="mistape_mistake_inner">'+textToHighlight+'</strong>';}
var selWithContextHighlighted=selToFindInContext.replace(textToHighlight,'<span class="mistape_mistake_outer">'+highlightedChars+'</span>');if(selExactMatch&&truncatedContext==context){previewText=truncatedContext.substring(0,selPos)+selWithContextHighlighted+truncatedContext.substring(selPos+selWithContext.length)||selWithContextHighlighted}
else{previewText=truncatedContext.replace(selWithContext,selWithContextHighlighted)||selWithContextHighlighted}
let isAllowed=(parentEl!==document.getElementById('mistape-widget-message'));return{isAllowed:isAllowed,selection:selChars,word:selWord,replace_context:selToFindInContext,context:truncatedContext,preview_text:previewText};}};document.addEventListener('keydown',(e)=>{if(e.ctrlKey&&e.keyCode==13){console.log('Ctrl+Enter pressed')
let data=Deco_Mistape.getSelectionData()
if(data&&data.isAllowed){data.post_id=0
try{[].forEach.call(document.body.classList,element=>{const postID=element.match(/postid-(.*)$/);if(postID)data.post_id=postID[1];})}
catch(err){}
data.action='mistape_report_error'
data.nonce=mistape_args.nonce
getFormData=object=>Object.keys(object).reduce((formData,key)=>{formData.append(key,object[key]);return formData;},new FormData())
fetch(mistape_args.ajaxurl,{method:'POST',mode:'same-origin',cache:'no-cache',credentials:'same-origin',body:getFormData(data),}).then(response=>{if(!response.ok){throw new Error('Network response was not ok');}
if(window.loveNotyf){window.loveNotyf("Спасибо за внимательность. Опечатка уже отправлена нашим редакторам")}}).catch(error=>{console.error(error)
if(window.errorNotyf){window.errorNotyf('Не получилось отправить сообщение об опечатке. Пожалуйста, попробуйте позже или напишите нам на bugs@tproger.ru')}})}}})