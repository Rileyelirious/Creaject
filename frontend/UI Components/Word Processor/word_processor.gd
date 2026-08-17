extends Control

func _on_editor_text_changed() -> void:
	%MarkdownLabel.markdown_text = %EditorText.text

func _on_hide_show_editor_pressed() -> void:
	%Editor.visible = not %Editor.visible
